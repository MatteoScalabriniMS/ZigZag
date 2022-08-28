using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    private Vector3 _platformPosition;

    private float _edgeSize;

    private void SpawnX()
    {
        _platformPosition.x += _edgeSize;
        Instantiate(platform, _platformPosition, Quaternion.identity); // creates new GameObject on screen
    }

    private void SpawnZ()
    {
        _platformPosition.z += _edgeSize;
        Instantiate(platform, _platformPosition, Quaternion.identity);
    }

    // Start is called before the first frame update
    private void Start()
    {
        _platformPosition = platform.transform.position;

        _edgeSize = platform.transform.localScale.x;

        for (int i = 0; i < 5; i++)
        {
            SpawnX();
            SpawnZ();
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}