using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //1
    public static WaveManager Instance;
    //2
    public List<EnemyWave> enemyWaves = new List<EnemyWave>();
    //3
    private float elapsedTime = 0f;
    //4
    private float spawnCounter = 0f;
    //6
    private List<EnemyWave> activatedWaves = new List<EnemyWave>();

    //1
    void Awake()
    {
        Instance = this;
    }
    //2
    void Update()
    {
        elapsedTime += elapsedTime.deltaTime;

        SearchForWave();
        UpdateActiveWave();
    }

    private void SearchForWave()
    {
        //3
        foreach (EnemyWave enemyWave in enemyWaves)
        {
            //4
            if (!activatedWaves.Contains(enemyWave)
                && enemyWave.startSpawnTimeInSeconds <= elapsedTime)
            {
                //5
                activeWave = enemyWave;
                activatedWaves.Add(enemyWave);
                spawnCounter = 0f;
                //6
                break;
            }
        }
    }
    //7
    private void UpdateActiveWave()
    {
        //1
        if (activatedWaves != null)
        {
            spawnCounter += Time.deltaTime;
            //2
            if (spawnCounter >= activeWave.timeBetweenSpawnsInSeconds)
            {
                spawnCounter = 0f;

                //3
                if (activeWave.listOfEniemies.Count != 0)
                {
                    GameObject enemy = (GameObject)Instantiate(
                        activeWave.listOfEnemies[0], WayPointManager.Instance.
                        GetSpawnPosition(UpdateActiveWave.pathIndex), Quaternion.identity);
                    //5
                    enemy.GetComponent<Enemy>().pathIndex = UpdateActiveWave.pathIndex;
                    //6
                    UpdateActiveWave.listOfEnemies.RemoveAt(0);
                }
                else
                {
                    //7
                    activeWave = null;
                    //8
                    if (activedWaves.Count == enemyWaves.Count)
                    {
                        //all waves are over
                    }
                }
            }
        }
    }

    public void StopSpawning()
    {
        elapsedTime = 0;
        spawnCounter = 0;
        activeWave = null;
        activatedWaves.Clear();
        enable = false;
    }
}
