using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AddTowerWindow : MonoBehaviour
{
    // the reference to the tower slot where the tower should be built
    public GameObject towerSlotToAddTowerTo;

    // the AddTower() method takes a single string parameter; the tower's type
    public void AddTower(string towerTypeAsString)
    {
        // Convert the string paramter that was passed into the TowerType enum
        TowerType type = (TowerType)Enum.Parse(typeof(TowerType), towerTypeAsString, true);

        // check that the player has enough gold to afford the chosen tower
        if (TowerManager.Instance.GetTowerPrice(type) <= GameManager.Instance.gold)
        {
            // subtract the tower's price from the player's gold
            GameManager.Instance.gold -= TowerManager.Instance.GetTowerPrice(type);

            // call CreateNewTower() on the TOwerManager and disable the AddTowerWindow
            TowerManager.Instance.CreateNewTower(towerSlotToAddTowerTo, type);
            gameObject.SetActive(false);
        }
    }
}
