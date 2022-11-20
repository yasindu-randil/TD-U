using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }

    }
    void Update()
    {
        //! Get the distance difference with Enemy object and the waypoint
        Vector3 dir = target.position - transform.position;
        //! Add the speed and normalize it 
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void Die()
    {
        UnityEngine.Debug.Log("Enemy Destroed");
        Destroy(gameObject);
    }

    // unit test function
    public void TestDie(int amount)
    {

        health -= amount;
        if (health < 0)
        {
            gameObject.SetActive(false);
        }
    }

    //! Update to the next waypoint.
    void GetNextWaypoint()
    {
        if( wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }



    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
