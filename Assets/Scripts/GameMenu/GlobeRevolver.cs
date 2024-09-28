using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeRevolver : MonoBehaviour
{
    public float globeRotationSpeed = 0.1f;
    public float grabRotationSpeed = 1f;
    bool drag = false;

    private LevelSelector levelSelector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        drag = true;
        float XaxisRotation = Input.GetAxis("Mouse X") * grabRotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * grabRotationSpeed;

        transform.Rotate(Vector3.down, -XaxisRotation);
        transform.Rotate(Vector3.right, YaxisRotation);
    }

    private void OnMouseExit()
    {
        drag = false;
    }

    private void FixedUpdate()
    {
        if (!drag)
        {
            transform.Rotate(0, globeRotationSpeed, 0);
        }
    }
}
