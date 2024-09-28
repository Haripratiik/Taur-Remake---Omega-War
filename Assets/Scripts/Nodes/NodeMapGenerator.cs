using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMapGenerator : MonoBehaviour
{
    public Transform holder;

    [SerializeField] int mapWidth = 2500;
    [SerializeField] int mapHeight = 1200;

    public float tileXOffset = 2f;
    public float tileZOffset = 3.5f;

    public GameObject hexTilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        CreateHexTileMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateHexTileMap ()
    {

        float mapXMin = -mapWidth / 2;
        float mapXMax = mapWidth / 2;

        float mapZMin = -mapHeight / 2;
        float mapZMax = mapHeight / 2;

        for( float x = mapXMin; x < mapXMax; x++)
        {
            for(float z = mapZMin; z< mapZMax; z++)
            {
                GameObject TempGO = Instantiate(hexTilePrefab);

                Vector3 pos;
                float y = Mathf.PerlinNoise(x * 1f, z * .3f) * 2f;

                if (z % 2 == 0)
                {
                    pos = new Vector3(x * tileXOffset, y, z * tileZOffset);
                }

                else
                {
                    pos = new Vector3(x * tileXOffset + tileXOffset / 2, y, z * tileZOffset);
                }

                StartCoroutine(SetTileInfo(TempGO, x, z, pos));
            }
        }
    }

    IEnumerator SetTileInfo(GameObject GO, float x, float z, Vector3 pos)
    {
        GO.transform.parent = holder;
        yield return new WaitForSeconds(0.0000001f);
        GO.name = x.ToString(); z.ToString();
        GO.transform.position = pos;
    }

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
