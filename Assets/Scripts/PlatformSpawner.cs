using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    private Vector3 _platformPosition;

    private float _edgeSize;

    [HideInInspector]
    public bool gameOver;

    public static PlatformSpawner Current;

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

    private void RandomSpawner()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
            SpawnX();
        else
            SpawnZ();
        
    }

    public void StartSpawn()
    {
        InvokeRepeating(nameof(RandomSpawner), 2f, 0.2f); // starts to invoke RandomSpawner after 2 seconds and every 02 seconds
    }

    private void Awake()
    {
        Current = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _platformPosition = platform.transform.position;

        _edgeSize = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            RandomSpawner();
        }
        
        StartSpawn();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameOver)
        {
            CancelInvoke(nameof(RandomSpawner));
        }
    }
}