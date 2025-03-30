using UnityEngine;
[System.Serializable]

public class Wave
{
    public int numEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true; 

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        // if there are no enemies left, + canspawn = False + max number of waves not achieved:
        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber+1 != waves.Length)
        {
            // waveName.text = waves[currentWaveNumber + 1].waveName
            spawnNextWave();
        }
        if(currentWaveNumber+1 == waves.Length)
        {
            GameManager.manager.GameOver();
        }
    }

    void spawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            //spawn one of the enemies listed in the array of enemies for the current wave number
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            //spawn enemy at one of the points put in waveSpawner array
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            //spawn the enemies of designated types in designated positions
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            //-1 from numEnemies for each one spawned
            currentWave.numEnemies--;
            //when to spawn enemies according to spawnInterval
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            //stop spawning enemies when designated number for wave spawned
            if (currentWave.numEnemies == 0)
            {
                canSpawn = false;
            }
        }
    }
}
