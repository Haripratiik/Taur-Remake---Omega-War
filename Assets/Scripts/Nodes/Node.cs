using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;
    private Renderer rend;

    public float raiseHeight;
    bool setScale;

    public float hoverHeight = 1;

    public Material gameoverMaterial;

    [Header("Optional")]
    public GameObject turret;

    // Start is called before the first frame update
    void Start()
    {
        setScale = true;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;

        Vector3 startPosistion = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.transform.position = startPosistion;
    }

    // Update is called once per frame
    void Update()
    {
        RaiseNode();

        WhenGameOver();
    }

    void OnMouseDown()
    {
        if (PauseMenu.gameIsPaused == false)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (!buildManager.CanBuild)
                return;

            if (turret != null)
            {
                Debug.Log("Can't place turret here!");
                return;
            }

            //Build turret
            buildManager.BuildTurretOn(this);

            //GameObject TurretToBuild = buildManager.getTurretToBuild();
            //Vector3 buildPosition = new Vector3(transform.position.x, transform.position.y - 0.8878487f, transform.position.z);
            //turret = (GameObject)Instantiate(TurretToBuild, buildPosition, Quaternion.Euler(new Vector3(180, 0, 180)));
        }
    }

    void OnMouseEnter()
    {
        if (PauseMenu.gameIsPaused == false)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (buildManager.CanBuild)
            {
                if (buildManager.HasMoney)
                {
                    rend.material.color = hoverColor;
                    Vector3 hoverpos = new Vector3(transform.position.x, transform.position.y + hoverHeight, transform.position.z);
                    transform.position = hoverpos;
                    return;
                }
                else
                {
                    rend.material.color = notEnoughMoneyColor;
                }

            }

            Vector3 hoverPos = new Vector3(transform.position.x, transform.position.y + hoverHeight, transform.position.z);
            transform.position = hoverPos;
        } else
        {
            Vector3 hoverPos = new Vector3(transform.position.x, transform.position.y + hoverHeight, transform.position.z);
            transform.position = hoverPos;
            rend.material.color = startColor;
        }
    }

    void OnMouseExit()
    {
        if (PauseMenu.gameIsPaused == false)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (buildManager.CanBuild)
            {
                rend.material.color = startColor;
                transform.position = new Vector3(transform.position.x, transform.position.y - hoverHeight, transform.position.z);
                return;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y - hoverHeight, transform.position.z);
        } else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - hoverHeight, transform.position.z);
            rend.material.color = startColor;
        }
    }

    void RaiseNode ()
    {
        if (turret != null)
        {
            if (setScale == true) 
            {
                //transform.position = new Vector3(transform.position.x, raiseHeight, transform.position.z);
                if (raiseHeight == 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
                } else
                {
                    transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z * 10 * raiseHeight / 5);
                }
                turret.transform.position = new Vector3(turret.transform.position.x, raiseHeight + 0.5878487f, turret.transform.position.z);
                setScale = false;
            }
        }
    }

    void WhenGameOver ()
    {
        if (MainNodeScript.gameOver == true)
        {
            rend.material = gameoverMaterial;
        }
    }
}
