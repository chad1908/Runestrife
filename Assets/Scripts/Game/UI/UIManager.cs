﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // the static reference to the UIManager
    public static UIManager Instance;
    // reference to the AddTowerWindow component
    public GameObject addTowerWindow;
    public GameObject towerInfoWindow;
    // References to the Text components of the TopBar
    public Text txtGold;
    public Text txtWave;
    public Text txtEscapedEnemies;

    public Transform enemyHealthBars;
    public GameObject enemyHealthBarPrefab;

    //this bit of code goes underneath GameObject towerInfoWindow; ---------------------------------------------------
    public GameObject winGameWindow;
    public GameObject loseGameWindow;
    public GameObject blackBackground;
    //----------------------------------------------------------------------------------------------------------------
    
    // Used in opening and closing the center window UI element for informing player of their current wave
    public GameObject centerWindow;

    // Used in displaying a red border to indicate an enemy has escaped
    public GameObject damageCanvas;

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

    public void ShowTowerInfoWindow(Tower tower)
    {
        towerInfoWindow.GetComponent<TowerInfoWindow>().tower = tower;
        towerInfoWindow.SetActive(true);
        UtilityMethods.MoveUiElementToWorldPosition(towerInfoWindow.
        GetComponent<RectTransform>(), tower.transform.position);
    }

    // these methods goes underneath ShowTowerInfoWindow() method ---------------------------------------------------------
    public void ShowWinScreen()
    {
        blackBackground.SetActive(true);
        winGameWindow.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        blackBackground.SetActive(true);
        loseGameWindow.SetActive(true);
    }

    // accepts the enemy that needs a health bar as it's sole parameter
    public void CreateHealthBarForEnemy(Enemy enemy)
    {
        // create a new health bar
        GameObject healthBar = Instantiate(enemyHealthBarPrefab);
        // parent the new health bar to EnemyHealthBars
        healthBar.transform.SetParent(enemyHealthBars, false);
        // pass teh enemy reference to the health bar
        healthBar.GetComponent<EnemyHealthBar>().enemy = enemy;
    }
    //--------------------------------------------------------------------------------------------------------------------

    // Center Window Methods, used for displaying current wave
    public void ShowCenterWindow(string text)
    {
        centerWindow.transform.Find("TxtWave").GetComponent<Text>().text = text;
        StartCoroutine(EnableAndDisableCenterWindow());
    }

    private IEnumerator EnableAndDisableCenterWindow()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(.4f);
            centerWindow.SetActive(true);

            yield return new WaitForSeconds(.4f);
            centerWindow.SetActive(false);
        }
    }

    // Used in the damage canvas for displaying a red border when and enemy escapes
    public void ShowDamage()
    {
        StartCoroutine(DoDamageAnimation());
    }

    private IEnumerator DoDamageAnimation()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(.1f);
            damageCanvas.SetActive(true);
            yield return new WaitForSeconds(.1f);
            damageCanvas.SetActive(false);
        }
    }
}
