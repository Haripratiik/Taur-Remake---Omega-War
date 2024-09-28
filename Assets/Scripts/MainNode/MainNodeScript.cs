using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainNodeScript : MonoBehaviour
{
    [Header("Attributes")]

    public int nodeHealth = 500;
    public int currentHealth;

    public int damage = 10;
    public int damageBombEnemy = 50;

    [Header("Unity Needs")]

    public float noEnviromentRadius;
    public GameObject mainTurret;

    public HealthBar healthBar;

    public static bool gameOver;

    Explosion explosion;

    // Start is called before the first frame update
    void Start() //Changed Start to Awake
    {
        //InvokeRepeating("NodeHealth", 0f, 0.5f);

        gameOver = false;

        currentHealth = nodeHealth;
        healthBar.SetMaxHealth(nodeHealth);

        Invoke("checkForEnviroment", 0.1f);

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            if (nodeHealth >= -1)
            {
                currentHealth -= damage;

                healthBar.SetHealth(currentHealth);
            }
        }

        if (other.gameObject.CompareTag("BombEnemy") == true)
        {
            //currentHealth -= damageBombEnemy;

            if (nodeHealth >= -1)
            {
                //currentHealth -= damageBombEnemy;
                other.GetComponent<Explosion>().Explode();

                TakeDamage(30);

                healthBar.SetHealth(currentHealth);
            }
        }
    }

    void checkForEnviroment()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, noEnviromentRadius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.CompareTag("Enviroment"))
            {
                Destroy(hitColliders[i].gameObject);
            }
        }
    }

    void GameOver ()
    {
        if (currentHealth <= 0)
        {
            gameOver = true;

            //Time.timeScale = 0.1f;
            //gameOverUI.SetActive(true);
        }
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void NodeHealth ()
    {
        Debug.Log(nodeHealth);
    }
}
