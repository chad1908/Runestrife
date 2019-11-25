using UnityEngine;
using System.Collections.Generic;
public class WayPointManager : MonoBehaviour
{
    //A static variable that holds a reference to this script.
    public static WayPointManager Instance;
    //The list of stored paths.
    public List<Path> Paths = new List<Path>();
    void Awake()
    {
        //Sets the value explained in entry 1.
        Instance = this;
    }
    //Returns the position of the enemy spawn point based on what path they will take.
    public Vector3 GetSpawnPosition(int pathIndex)
    {
        return Paths[pathIndex].WayPoints[0].position;
    }
}
//Path is defined here as a class containing a list of waypoints, which are stored as Transforms.
[System.Serializable]
public class Path
{
    public List<Transform> WayPoints = new List<Transform>();
}
