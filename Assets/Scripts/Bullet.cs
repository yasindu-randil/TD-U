using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public GameObject ImpactEffect;

    public void seekTarget(Transform targetTemp )
    {
        target = targetTemp;
    }

    // Update is called once per frame
    void Update()
    {
        if( target == null )
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectObj = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectObj, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
