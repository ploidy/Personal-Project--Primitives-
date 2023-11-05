using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;
    public float spawnRange = 50f; 
    public float spawnTimer;
    float timer;
    //public Camera camFOV;

    // Start is called before the first frame update
    void Start()
    {
     //camFOV = Camera.main;
     
    

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }
    void SpawnEnemy()
    {
        //float camHeight = 2f * camFOV.orthographicSize + 10;
        //float camWidth = camFOV.orthographicSize * camFOV.aspect + 10;
        float spawnPosX = player.transform.position.x + Random.Range(-spawnRange, spawnRange); 
        float spawnPosZ = player.transform.position.z + Random.Range(-spawnRange, spawnRange); 

        Vector3 position = new Vector3(spawnPosX,1.6f,spawnPosZ);

        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = position;
        
    }
 

}
