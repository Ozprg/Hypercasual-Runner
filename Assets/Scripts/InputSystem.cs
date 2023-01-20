using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private float _lastFrameTouchPositionX;
    private float _moveFactorX;
    public float moveFactorX => _moveFactorX;
    private bool _isFirstInputDetected;


    // public float moveFactorX { get; private set; }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // İlk bastığım an
        {
            if (!_isFirstInputDetected)
            {
                LevelController.Instance.FirstInputDetected();
                _isFirstInputDetected = true;
            }

            _lastFrameTouchPositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0)) // Basılı tuttuğun an
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameTouchPositionX;
            _lastFrameTouchPositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0)) // Kaldırdığım an
        {
            _moveFactorX = 0f;
        }
    }
}
