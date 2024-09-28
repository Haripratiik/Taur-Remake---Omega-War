using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTurretController : MonoBehaviour
{
    [Header("Attributes")]

    public float rotationDamp = 5f;
    public float range = 15f;
    float heightOffset;

    [Header("Unity Needs")]

    private Transform enemyShoot;

    public string enemy = "Enemy";
    public GameObject closestEnemy = null;

    private static GameObject thisGameObjectInstance;

    Node nodeScript;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        //heightOffset = nodeScript.raiseHeight * 1.2f;

        if (thisGameObjectInstance != null)
        {
            Destroy(this.gameObject);
        }
        thisGameObjectInstance = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyShoot == null) return;

        Turn();
    }

    void Turn()
    {
        Vector3 pos = closestEnemy.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(-pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationDamp * Time.deltaTime);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range + heightOffset);
    }

    void UpdateTarget ()
    {
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemiess = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        enemiess.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("BombEnemy")));

        float closestDistToEnemy = Mathf.Infinity;

        foreach (GameObject enemy in enemiess)
        {
            float distToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distToEnemy < closestDistToEnemy)
            {
                closestDistToEnemy = distToEnemy;
                closestEnemy = enemy;
            }

            if (closestEnemy != null && closestDistToEnemy <= range + heightOffset)
            {
                enemyShoot = closestEnemy.transform;
            }
            else {
                enemyShoot = null;
            }
        }
    }

}
