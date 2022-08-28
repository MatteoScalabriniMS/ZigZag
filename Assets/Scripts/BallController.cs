using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;

    private bool _isStarted; // always initialized as false

    private bool _gameOver;

    private Rigidbody _rb;

    private Camera _mainCamera;

    private void ChangeDirection()
    {
        // if ball moves in z axis, stop moving in z and start in x
        if (_rb.velocity.z > 0)
        {
            _rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (_rb.velocity.x > 0)
        {
            _rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_isStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rb.velocity = new Vector3(speed, 0, 0);
                _isStarted = true;
            }
        }

        // raycast checks the position of the object casting a ray from the obj position to under the obj
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            _gameOver = true;
            CameraController.Current.gameOver = true;
            PlatformSpawner.Current.gameOver = true;

            // make the ball fall
            _rb.velocity = new Vector3(0, -25f, 0);
        }


        // 0 is the sx mouse button
        if (Input.GetMouseButtonDown(0) && !_gameOver)
        {
            ChangeDirection();
        }
    }
}