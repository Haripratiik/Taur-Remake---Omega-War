using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticNodes : MonoBehaviour
{

    private static StaticNodes staticNodes;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (staticNodes == null)
        {
            
            staticNodes = this;
        } else
        {
            Destroy(gameObject);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
