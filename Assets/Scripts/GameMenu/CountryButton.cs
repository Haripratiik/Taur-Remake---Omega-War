using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CountryButton : MonoBehaviour
{
    public Color highlightColor;
    Color startColor;
    private Renderer rend;

    LevelSelector levelSelector;

    bool canSelect = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        startColor = rend.material.color;

        if (rend.material.color != Color.black)
        {
            rend.material.color = startColor;

            //canSelect = true;
        }
        else
        {
            //canSelect = false;
            this.rend.material.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (rend.material.color != Color.black)
        {
            SceneManager.LoadScene(this.name);

        } else
        {
            this.rend.material.color = Color.black;
        }
    }

    private void OnMouseEnter()
    {
        if (rend.material.color != Color.black)
        {
            rend.material.color = highlightColor;

        }
        else
        {
            this.rend.material.color = Color.black;
        }

    }

    private void OnMouseExit()
    {
        if (rend.material.color != Color.black)
        {
            rend.material.color = startColor;

        }
        else
        {
            this.rend.material.color = Color.black;
        }
    }
}
