using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // the static reference to the UIManager
    public static UIManager Instance;
    // reference to the AddTowerWindow component
    public GameObject addTowerWindow;
    // References to the Text components of the TopBar
    public Text txtGold;
    public Text txtWave;
    public Text txtEscapedEnemies;

    // Set instance to the UIManager script
    void Awake()
    {
        Instance = this;
    }

    // Update the gold, wave and escaped enemies Text values
    private void UpdateTopBar()
    {
        txtGold.text = GameManager.Instance.gold.ToString();
        txtWave.text = "Wave " + GameManager.Instance.waveNumber + " / " + WaveManager.Instance.enemyWaves.Count;
        txtEscapedEnemies.text = "Escaped Enemies " + GameManager.Instance.escapedEnemies + " / " + GameManager.Instance.maxAllowedEscapedEnemies;
    }

    // Takes a Tower Slot parameter, passes it along to the AddTowerWindow field and shows it at the position of the slot
    public void ShowAddTowerWindow(GameObject towerSlot)
    {
        addTowerWindow.SetActive(true);
        addTowerWindow.GetComponent<AddTowerWindow>().towerSlotToAddTowerTo = towerSlot;
        UtilityMethods.MoveUiElementToWorldPosition(addTowerWindow.GetComponent<RectTransform>(), towerSlot.transform.position);
    }

    void Update()
    {
        UpdateTopBar();
    }
}
