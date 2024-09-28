using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private DataPresistanceManager dataPresistanceManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("GameMenuScene");
        DataPresistanceManager.instance.NewGame();
    }

    public void LoadGameYes ()
    {
        SceneManager.LoadScene("GameMenuScene");
        DataPresistanceManager.instance.LoadGame();
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
