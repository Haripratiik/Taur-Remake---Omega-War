using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDataPresistance
{
    MainNodeScript mainNodeScript;

    [Header ("Player Stats")]

    public static int EnergyModules;
    public int energyModules;
    public int startEnergyModule = 100;

    [Header("Player Unlocks")]

    public int playerXP;
    public int PlayerHP; //base Health is 1200, each level provides +200

    // Start is called before the first frame update
    void Start()
    {
        EnergyModules = EnergyModules + startEnergyModule;
        energyModules = EnergyModules;
        //PlayerHP = mainNodeScript.nodeHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.energyModules = data.currentEnergyModulesCount;
    }

    public void SaveData(ref GameData data)
    {
        data.currentEnergyModulesCount = this.energyModules;
    }
}
