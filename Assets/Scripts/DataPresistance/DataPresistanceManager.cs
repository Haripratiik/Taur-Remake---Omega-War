using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPresistanceManager : MonoBehaviour
{
    private GameData gameData;

    private List<IDataPresistance> dataPresistenceObjects;

    public static DataPresistanceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Data Presistance Manager script in the scene.");
        }

        instance = this;
    }

    private void Start()
    {
        this.dataPresistenceObjects = FindAllDataPresistanceObjects();
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //If no saved Data, go back to defaults
        if(this.gameData == null)
        {
            Debug.Log("No saved Data found, going back to defaults");
            NewGame();
        }

        Debug.Log("Loaded Level" + gameData.currentLevelOn);
        Debug.Log("Loaded EnergyModule Count" + gameData.currentEnergyModulesCount);

        //Push all the saved data to the scripts that need it
        foreach (IDataPresistance dataPresistanceObj in dataPresistenceObjects)
        {
            dataPresistanceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        //Pass the data to the other scripts so that they are able to update it
        foreach (IDataPresistance dataPresistanceObj in dataPresistenceObjects)
        {
            dataPresistanceObj.SaveData(ref gameData);
        }

        //Debug.Log("Saved Level" + gameData.currentLevelOn);
        Debug.Log("Saved EnergyModule Count" + gameData.currentEnergyModulesCount);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPresistance> FindAllDataPresistanceObjects()
    {
        IEnumerable<IDataPresistance> dataPresistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPresistance>();

        return new List<IDataPresistance>(dataPresistenceObjects);
    }
}
