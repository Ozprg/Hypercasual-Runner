using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Vector3 _clickedScreenPosition;
    private Vector3 _clickedPlayerPosition;

    [Header("Movement Settings")]
    
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _slideSpeed;
    


    void Start()
    {
        
    }

    
    void Update()
    {
        MoveForward();
        Swerve();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;

    }

    private void Swerve ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickedScreenPosition = Input.mousePosition;
            _clickedPlayerPosition = transform.position;
        
       }

        else if (Input.GetMouseButton(0))
        {
            float _xScreenDiff = Input.mousePosition.x - _clickedScreenPosition.x; //
            _xScreenDiff /= Screen.width;
            _xScreenDiff *= _slideSpeed;

            Vector3 _position = transform.position;
            _position.x = _clickedPlayerPosition.x + _xScreenDiff;
            transform.position = _position;

            //transform.position = _clickedPlayerPosition + Vector3.right * _xScreenDiff;
        }

    }
}
