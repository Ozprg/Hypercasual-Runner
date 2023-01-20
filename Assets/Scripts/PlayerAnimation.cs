using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private int runAnim = Animator.StringToHash("Run");
    private readonly int danceAnim = Animator.StringToHash("Dance");

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        LevelController.Instance.OnFirstInputDetected += OnFirstInputDetected;
        LevelController.Instance.OnPlayerCompletedLevel += OnPlayerCompletedLevel;
    }

    private void OnDisable()
    {
        LevelController.Instance.OnFirstInputDetected -= OnFirstInputDetected;
        LevelController.Instance.OnPlayerCompletedLevel -= OnPlayerCompletedLevel;
    }

    private void OnFirstInputDetected()
    {
        if (_animator)
        {
            _animator.SetTrigger(runAnim);
        }
    }

    private void OnPlayerCompletedLevel()
    {
        if (_animator)
        {
            _animator.SetTrigger(danceAnim);
        }
    }
}