using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    public GameObject ball;

    public float lerpRate;

    [HideInInspector]
    public bool gameOver;
    
    public static CameraController Current;

    private Vector3 _offset; // distance between ball and camera

    private void Awake()
    {
        Current = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // _offset is calculated as the difference between the ball and the object linked to this script (for instance, the camera)
        _offset = ball.transform.position - transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameOver)
            Follow();
    }

    private void Follow()
    {
        var cameraPos = transform.position;
        var cameraTargetPos = ball.transform.position - _offset;

        // move camera from starting point to end point at a certain rate
        // Time.deltatime allows the movement to be stedier regarding of your pc processor
        cameraPos = Vector3.Lerp(cameraPos, cameraTargetPos, lerpRate * Time.deltaTime);

        transform.position = cameraPos;
    }
}