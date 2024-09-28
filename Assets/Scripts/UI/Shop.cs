using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint spiderTurret;
    public TurretBlueprint silencerTurret;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSpiderTurret ()
    {
        Debug.Log("Purchased Spider");
        buildManager.SelectTurretToBuild(spiderTurret);
    }

    public void SelectSilencerTurret()
    {
        Debug.Log("Purchased Silencer");
        buildManager.SelectTurretToBuild(silencerTurret);
    }
}
