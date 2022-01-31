using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerSpawner : MonoBehaviour
{
    [SerializeField] public Transform[] spawnpoints;
    [SerializeField] public Transform slowerPrefab;
    public float timeUntilSpawn;
    public float timeBetweenSpawn = 8;
    
    // Start is called before the first frame update
    void Start()
    {
        timeUntilSpawn = timeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUntilSpawn >= 0)
        {
            timeUntilSpawn -= Time.deltaTime;
        }

        else
        {
            int _randomIndex = Random.Range(0, spawnpoints.Length);
            Instantiate(slowerPrefab, new Vector3(spawnpoints[_randomIndex].transform.position.x,
            spawnpoints[_randomIndex].transform.position.y,  spawnpoints[_randomIndex].transform.position.z), Quaternion.identity);
            timeUntilSpawn = timeBetweenSpawn;
        }
    }
}
