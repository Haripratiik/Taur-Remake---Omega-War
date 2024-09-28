using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] UVs;
    Color[] colors;

    [Header ("Tree Editor")]
    public GameObject[] Enviroment;

    public float numberOfTrees;
    public float treeSpawnRadias;

    public GameObject meshGenerator;

    [Header ("Terrain Editor")]
    public int xSize = 20;
    public int zSize = 20;

    public Gradient terrainGradient;

    float minTerrainHeight;
    float maxTerrainHeight;

    public MeshRenderer rend;
    public Material corruption;
    public Material startColor;

    public float terrainChangerX;
    public float terrainChangerZ;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        GenerateTrees();

        rend.material = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        WhenGameWin();
    }

    void CreateShape ()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i=0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * terrainChangerX, z * terrainChangerZ) * 1.1f;
                vertices[i] = new Vector3(x, y, z);

                if (y > maxTerrainHeight)
                    maxTerrainHeight = y;

                if (y < minTerrainHeight)
                    minTerrainHeight = y;

                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {

            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        UVs = new Vector2[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                UVs[i] = new Vector2((float)x / xSize, (float)z / zSize);

                i++;
            }
        }

        colors = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);
                colors[i] = terrainGradient.Evaluate(height);

                i++;
            }
        }

    }

    void GenerateTrees ()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            int rand = Random.Range(0, Enviroment.Length);
            Vector3 pos = Random.insideUnitCircle * treeSpawnRadias;
            GameObject tree = Instantiate(Enviroment[rand], new Vector3(pos.x, 100, pos.y), Quaternion.identity);

            tree.transform.SetParent(meshGenerator.transform);

            if (tree.transform.position.y <= 0.46)
            {
                Destroy(tree.gameObject);
            }
        }
    }


    void UpdateMesh ()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = UVs;
        mesh.colors = colors;

        mesh.RecalculateNormals();

        mesh.RecalculateBounds();
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    void WhenGameWin()
    {
        if (WaveSpawner.GameWon == true)
        {
            rend.material = corruption;
        }
    }
}
