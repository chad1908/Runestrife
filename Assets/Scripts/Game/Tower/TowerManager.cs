using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public struct TowerCost
{
    //public TowerType TowerType; //--------------------------------Waiting on Asher's part to finish
    public int Cost;
}

public class TowerManager : MonoBehaviour
{
    //As this is another singleton, a static reference to this script is stored away in Instance
    public static TowerManager Instance;

    //References to the tower prefabs
    public GameObject stoneTowerPrefab;
    public GameObject fireTowerPrefab;
    public GameObject iceTowerPrefab;

    //Store the cost of each type of tower in a list
    public List<TowerCost> TowerCosts = new List<TowerCost>();

    //Sets the Instance variable to this script
    void Awake()
    {
        Instance = this;
    }

    //Accepts a tower slot and a type of tower as parameters, and creates a new copy of the chosen tower at the position of the tower slot
<<<<<<< HEAD
    //public void CreateNewTower(GameObject slotToFill, TowerType towerType) //--------------------------------Waiting on Asher's part to finish
    //{
    //    switch (towerType)
    //    {
    //        case towerType.Stone:
    //            Instantiate(stoneTowerPrefab, slotToFill.transform.position, Quaternion.identity);
    //            slotToFill.gameObject.SetActive(false);
    //            break;
    //        case towerType.Fire:
    //            Instantiate(fireTowerPrefab, slotToFill.transform.position, Quaternion.identity);
    //            slotToFill.gameObject.SetActive(false);
    //            break;
    //        case towerType.Ice:
    //            Instantiate(iceTowerPrefab, slotToFill.transform.position, Quaternion.identity);
    //            slotToFill.gameObject.SetActive(false);
    //            break;
    //    }
    //}
=======
    public void CreateNewTower(GameObject slotToFill, TowerType towerType) //--------------------------------Waiting on Asher's part to finish
    {
        //switch (towerType)
        //{
        //    case towerType.Stone:
        //        Instantiate(stoneTowerPrefab, slotToFill.transform.position, Quaternion.identity);
        //        slotToFill.gameObject.SetActive(false);
        //        break;
        //    case towerType.Fire:
        //        Instantiate(fireTowerPrefab, slotToFill.transform.position, Quaternion.identity);
        //        slotToFill.gameObject.SetActive(false);
        //        break;
        //    case towerType.Ice:
        //        Instantiate(iceTowerPrefab, slotToFill.transform.position, Quaternion.identity);
        //        slotToFill.gameObject.SetActive(false);
        //        break;
        //}
    }
>>>>>>> 9265e85bf02c418c09179a6e42115349f65d9203

    //a LINQ utility method to easily get the price of a tower type
    //public int GetTowerPrice(TowerType towerType) //--------------------------------Waiting on Asher's part to finish
    //{
    //    return (from towerCost in TowerCosts
    //            where towerCost.TowerType == towerType
    //            select towerCost.Cost).FirstOrDefault();
    //}
}
