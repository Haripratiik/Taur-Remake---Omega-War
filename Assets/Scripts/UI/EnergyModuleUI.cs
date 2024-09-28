using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyModuleUI : MonoBehaviour
{
    public TextMeshProUGUI energyModuleText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        energyModuleText.text = PlayerStats.EnergyModules.ToString();
    }
}
