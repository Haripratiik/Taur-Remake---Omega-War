using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public TextMeshProUGUI energyModules;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        energyModules.text = "Energy Modules Left: " + PlayerStats.EnergyModules.ToString();
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }

    public void BuildMenu ()
    {
        SceneManager.LoadScene("BuildScene");
    }
}
