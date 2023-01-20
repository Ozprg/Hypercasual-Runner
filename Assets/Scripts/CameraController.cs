using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Transform focus;
    [SerializeField][Range(1f, 20f)] private float _distance;
    [SerializeField][Range(0f, 2f)] private float _focusRadius;

    private Vector3 focusPoint;

    private void OnEnable()
    {
        LevelController.Instance.OnLevelIsCreated += OnLevelIsCreated;
    }

    private void OnDisable()
    {
        LevelController.Instance.OnLevelIsCreated -= OnLevelIsCreated;
    }

    private void Update()
    {
        UpdateFocusPoint();
        Vector3 lookDirection = transform.forward;
        transform.localPosition = focusPoint - lookDirection * _distance;
    }

    private void UpdateFocusPoint()
    {
        if (focus)
        {
            Vector3 targetPoint = focus.position;

            if (_focusRadius > 0f)
            {
                float distance = Vector3.Distance(targetPoint, focusPoint);

                if (distance > _focusRadius)
                {
                    focusPoint = Vector3.Lerp(targetPoint, focusPoint, _focusRadius / distance);
                }
            }
            else
            {
                focusPoint = targetPoint;
            }
        }
    }

    private void OnLevelIsCreated(GameLevel currentGameLevel)
    {
        if (currentGameLevel.player)
        {
            focus = currentGameLevel.player.transform;
        }
    }
}