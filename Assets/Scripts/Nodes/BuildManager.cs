using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private static TurretBlueprint turretToBuild;

    public bool raiseNodeUp;

    public GameObject SpiderTurret;
    public GameObject SilencerTurret;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }


    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
        Debug.Log("Turret blueprint is" + turretToBuild.cost);
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.EnergyModules >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {

        if (PlayerStats.EnergyModules < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.EnergyModules -= turretToBuild.cost;

        Vector3 buildPosition = new Vector3(node.transform.position.x, node.raiseHeight + 0.5878487f, node.transform.position.z);
        Debug.Log("Turret to build is " + turretToBuild.cost);
        GameObject turret1 = (GameObject)Instantiate(turretToBuild.turretPrefab, buildPosition, Quaternion.Euler(new Vector3(180, 0, 180)));
        GameObject turret2 = (GameObject)Instantiate(turretToBuild.turretPrefab, buildPosition, Quaternion.Euler(new Vector3(180, 0, 180)));
        Debug.Log("Turret supposed to be built is" + turret2.name);
        node.turret = turret2;
        if (node.turret = turret2)
        {
            raiseNodeUp = true;
        }

        Debug.Log("Money Left:" + PlayerStats.EnergyModules);
    }
}
