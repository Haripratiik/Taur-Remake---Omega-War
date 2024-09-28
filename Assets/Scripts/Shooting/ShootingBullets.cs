using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    [Header("Attributes")]

    public float damage = 10f;
    public float rateOfFire = 1f;
    public float impactForce = 10f;
    public float bulletSpeed = 5f;
    public bool bulletSpread = true;
    public Vector3 bulletSpreadVarience = new Vector3(0.1f, 0.1f, 0.1f);

    [Header("Unity Needs")]
    [SerializeField] private MainTurretController closestEnemy;
    public Transform bulletSpawnPoint;
    public ParticleSystem bulletEffect;
    public ParticleSystem muzzleFlash;
    public TrailRenderer bulletTrail;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, rateOfFire);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }
    void Shoot ()
    {
        Vector3 direction = GetDirection();

        RaycastHit hitInfo;
        if (Physics.Raycast(bulletSpawnPoint.transform.position, direction, out hitInfo))
        {
            //Debug.Log(hitInfo.transform.name);

            EnemyController target =  hitInfo.transform.GetComponent<EnemyController>();
            if (target != null)
            {
                //muzzleFlash.Play();

                TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPoint.transform.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, hitInfo, target));

                //target.TakeDamage(damage);
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);

            }

        }

    }

    private Vector3 GetDirection()
    {
        Vector3 direction = -bulletSpawnPoint.transform.forward;

        if (bulletSpread)
        {
            direction += new Vector3(
                    Random.Range(-bulletSpreadVarience.x, bulletSpreadVarience.x),
                    Random.Range(-bulletSpreadVarience.y, bulletSpreadVarience.y),
                    Random.Range(-bulletSpreadVarience.z, bulletSpreadVarience.z)
                );
            direction.Normalize();
        }

        return direction;
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit, EnemyController Target)
    {
        float time = 0;
        Vector3 startPosition = bulletSpawnPoint.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime * bulletSpeed;

            yield return null;
        }

        Trail.transform.position = Hit.point;
        Instantiate(bulletEffect, Hit.point, Quaternion.LookRotation(Hit.normal));
        Target.TakeDamage(damage);

        Destroy(Trail.gameObject, Trail.time);
    }

}
