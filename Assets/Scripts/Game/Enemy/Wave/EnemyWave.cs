using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//1
[Serializable]
public class EnemyWave : MonoBehaviour
{
    //2
    public int pathIndex;
    //3
    public float startSpawnTimeInSeconds;
    //4
    public float timeBetweenSpawnInSeconds = 1f;
    //5
    public List<GameObject> listOfEnemies = new List<GameObject>();
}
