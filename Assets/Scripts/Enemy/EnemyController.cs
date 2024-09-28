using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //public Transform player;

    [Header("Attributes")]

    public float rotationDamp = 1.2f;
    public float movementSpeed = 13f;
    public float health = 40f;
    public int dnaWorth = 1;

    public bool canDie = true;

    [Header("Unity Needs")]

    bool moveCheck;

    public GameObject mainNode;
    public DNABar dnaBar;

    Explosion explosion;

    // Start is called before the first frame update
    void Start()
    {
        mainNode = GameObject.FindGameObjectWithTag("Main_Node");
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Movement();
    }

    void Turn ()
    {
        if (moveCheck == false)
        {
            Vector3 pos = mainNode.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationDamp * Time.deltaTime);
        }
       
    }

    void Movement ()
    {
        if (moveCheck == false)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Main_Node"))
        {
            moveCheck = false;
         //Destroy(this.gameObject);
        }
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            
            if (gameObject.CompareTag("BombEnemy"))
            {
                GetComponent<Explosion>().Explode();
                
                Destroy(gameObject);
            } else
            {
                Die();
            }
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
