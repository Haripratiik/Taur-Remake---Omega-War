using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public int currentLevelOn;
    public int currentEnergyModulesCount;

    //Values in here will be the default/ starting values when a NEW game is loaded
    public GameData()
    {
        this.currentLevelOn = 1;
        this.currentEnergyModulesCount = 100;
    }
}
