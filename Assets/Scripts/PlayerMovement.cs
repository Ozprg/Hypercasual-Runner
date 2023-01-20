using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerAge;
    public LevelController controller;

    [SerializeField][Range(0f, 5f)] private float _swerveSpeed = 0.5f;
    [SerializeField][Range(1f, 100f)] private float _moveSpeed;
    [SerializeField][Range(0f, 2f)] private float _platformEdgeValue;

    private InputSystem _inputSystem;
    private float _playerMaxValueX;
    private bool _isLevelFinished;
    private bool _isFirstInputDetected;


    private void OnEnable()
    {
        LevelController.Instance.OnPlayerCompletedLevel += OnPlayerCompletedLevel;
        LevelController.Instance.OnFirstInputDetected += OnFirstInputDetected;
    }

    private void OnDisable()
    {
        LevelController.Instance.OnPlayerCompletedLevel -= OnPlayerCompletedLevel;
        LevelController.Instance.OnFirstInputDetected -= OnFirstInputDetected;
    }

    private void Start()
    {
        _inputSystem = GetComponent<InputSystem>();

        float currentPlatformScaleX = LevelController.Instance.levelCreator.platform.transform.localScale.x;
        _playerMaxValueX = currentPlatformScaleX / 2;
    }

    private void Update()
    {
        if (!_isLevelFinished)
        {
            if (_isFirstInputDetected)
            {
                float swerveAmount = _swerveSpeed * _inputSystem.moveFactorX * Time.deltaTime;
                float forwardAmount = _moveSpeed * Time.deltaTime;

                transform.Translate(swerveAmount, 0, forwardAmount);

                float _playerMaxClampValueX = _playerMaxValueX - _platformEdgeValue;
                if (transform.position.x > _playerMaxClampValueX)
                {
                    transform.position = new Vector3(_playerMaxClampValueX, transform.position.y, transform.position.z);
                }
                else if (transform.position.x < -_playerMaxClampValueX)
                {
                    transform.position = new Vector3(-_playerMaxClampValueX, transform.position.y, transform.position.z);
                }
            }
        }
    }

    private void OnPlayerCompletedLevel()
    {
        _isLevelFinished = true;
    }

    private void OnFirstInputDetected()
    {
        if (!_isFirstInputDetected)
        {
            _isFirstInputDetected = true;
        }
    }
}