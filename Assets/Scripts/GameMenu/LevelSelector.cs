using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour, IDataPresistance
{
    public GameObject[] countryButtons;

    public static bool canSelectLevel;

    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < countryButtons.Length; i++)
        {
            if (i+1 > levelReached)
            {
                //countryButtons[i].transform.position = new Vector3(countryButtons[i].transform.position.x, countryButtons[i].transform.position.y + 0.000001f, countryButtons[i].transform.position.z);
                //countryButtons[i].SetActive(false);

                countryButtons[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
            }
        }

    }

    public void LoadData(GameData data)
    {
        //PlayerPrefs.GetInt("levelReached") = data.currentLevelOn;
    }

    public void SaveData(ref GameData data)
    {
         //data.currentLevelOn = this.levelReached;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
