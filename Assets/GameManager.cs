using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWonUI;

    public int leveltoUnlock = 2;

    private LevelSelector levelSelector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    void GameOver ()
    {
        if (MainNodeScript.gameOver == true)
        {
            Time.timeScale = 0.1f;
            gameOverUI.SetActive(true);
        }
    }

    public void WinLevel ()
    {
        Debug.Log("Level Won!");

        PlayerPrefs.SetInt("levelReached", leveltoUnlock);

        Time.timeScale = 0.1f;
        gameWonUI.SetActive(true);
    }
}
