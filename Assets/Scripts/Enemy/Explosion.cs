using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //public float delay = 3f;

    public float blastRadius = 5;
    public float explosionFloat = 700;

    public GameObject explosionEffect;
    GameObject thisgameObject;

    //float countDown;
    bool hasExploded = false;

    EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        thisgameObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasExploded == true)
        {
            Destroy(thisgameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void Explode1()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //Collider[] colliders = Physics.OverlapSphere(transform.position, explosion.blastRadius);
        //foreach (Collider nearbyobject in colliders)
        //{
        //    Rigidbody rb = nearbyobject.GetComponent<Rigidbody>();
        //    if (rb != null)
        //    {
        //        rb.AddExplosionForce(explosion.explosionFloat, transform.position, explosion.blastRadius);
        //    }

        //    EnemyController enemyControll = nearbyobject.GetComponent<EnemyController>();
        //    if (enemyControll != null)
        //    {
        //        enemyControll.TakeDamage(50);
        //    }

        //    MainNodeScript mainNodeScript = nearbyobject.GetComponent<MainNodeScript>();
        //    if (mainNodeScript != null)
        //    {
        //        mainNodeScript.TakeDamage(30);
        //    }
        //}

        //for (int i = 0; i < colliders.Length; i++)
        //{
        //   //if (colliders[i].GetComponent<EnemyController>() == true) 
        //    {
        //        //colliders[i].GetComponent<EnemyController>().TakeDamage(50);
        //    }

        //    //if (colliders[i].GetComponent<MainNodeScript>() == true)
        //    {
        //        //colliders[i].GetComponent<MainNodeScript>().TakeDamage(30);
        //    }
        //}

        Destroy(explosionEffect);
        //Destroy(gameObject);

        hasExploded = true;
    }

    public void Explode ()
    {
        Explode1();
    }
}
