using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public Transform enemy1;
    public Transform spawnPoint1; 
    public Transform spawnPoint2;

    public float timeToNextWave;
    public float timeToStart;

    public int[] wave;
    public int waveIndex;

    // Start is called before the first frame update
    void Start()
    {
        timeToStart = 2f;
        timeToNextWave = 5f;
        waveIndex = 0;
        //Keeps track of the number of enemies per wave
        //wave[0] = 4; //slow, spawn 1
        //wave[1] = 6; //pairs of 2, slow, spawn 1
        //wave[2] = 5; //same as wave1, but last 2 come out at once, spawn 2
    }

    // Update is called once per frame
    void Update()
    {

        //time between waves, not single enemies
        if (timeToStart <= 0f)
        {
            SpawnWave();
            timeToStart = timeToNextWave;
        }

        timeToStart -= Time.deltaTime;
    }

    void SpawnWave()//use the int to determine how many times to do the for loop, use the float as a timer: wave[waveIndex]
    {
        SpawnEnemy1();
        waveIndex++;
    }

    void SpawnEnemy1()
    {
        Instantiate(enemy1, spawnPoint2.position, spawnPoint2.rotation);
    }
}
