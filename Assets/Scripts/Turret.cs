using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity - Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;


    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);  
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemies = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemies < shortestDistance)
            {
                shortestDistance = distanceToEnemies;
                nearestEnemy = enemy;
            }

        }

        if( nearestEnemy != null && shortestDistance <= range )
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        // Smooth the transition
        Vector3 rotation = Quaternion.Lerp( partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;

        }

        // every second fire countdown will be reduced by one
        fireCountDown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        // Object casting
        GameObject bulletTemp = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // find the component
        Bullet bullet = bulletTemp.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.seekTarget(target);
        }
    }

    void onDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, range);
    }
}
