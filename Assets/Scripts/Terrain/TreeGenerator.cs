using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [Header("Tree Editor")]
    public GameObject[] Enviroment;

    public float numberOfTrees;
    public float treeSpawnRadias;

    public GameObject treeGenerator;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTrees();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateTrees()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            int rand = Random.Range(0, Enviroment.Length);
            Vector3 pos = Random.insideUnitCircle * treeSpawnRadias;
            GameObject tree = Instantiate(Enviroment[rand], new Vector3(pos.x, 100, pos.y), Quaternion.identity);

            tree.transform.SetParent(treeGenerator.transform);

            if (tree.transform.position.y <= 0.46)
            {
                Destroy(tree.gameObject);
            }
        }
    }
}
