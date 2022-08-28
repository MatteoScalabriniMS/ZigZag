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

    private void RandomSpawner()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
            SpawnX();
        else
            SpawnZ();
        
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
    }

    // Update is called once per frame
    private void Update()
    {
    }
}