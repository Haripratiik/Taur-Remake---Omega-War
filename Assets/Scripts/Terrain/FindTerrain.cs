using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTerrain : MonoBehaviour
{

    public MeshRenderer rend;
    public Material corruption;
    public Material startColor;

    // Start is called before the first frame update
    void Start()
    {
        //rend = gameObject.GetComponent<MeshRenderer>();
        //rend.material.color = Color.black;
        rend.material = startColor;

        FindTerrains();
    }

    // Update is called once per frame
    void Update()
    {
        WhenGameWin();
    }

    public void FindTerrains()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo))
        {
            transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
        } else
        {
            ray = new Ray(transform.position, transform.up);
            if(Physics.Raycast(ray, out hitInfo))
            {
                transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
            }
        }
    }

    void WhenGameWin()
    {
        if (WaveSpawner.GameWon == true)
        {
            rend.material = corruption;
        }
    }
}
