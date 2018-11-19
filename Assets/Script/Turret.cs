﻿using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;

    public float range;

    public string enemyTag = "Enemy";

    private float angle;

    public float fireRate = 1f;
    private float fireCountdown = 0;

    public GameObject ShootPrefab;
    public Transform firePoint;

    // Use this for initialization
    void Start ()
	{
	    InvokeRepeating("UpdateTarget",0f,0.5f);	
	}

    void UpdateTarget() // évitez que ça fasse à chaque frame ça serai trop 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy!=null&&shortestDistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.up = target.transform.position - transform.position;

        if (this.tag == "turret_Shoot")  //demander diff entre gameobject et this
        {
            if (fireCountdown<=0)
            {
                Shoot();
                fireCountdown = 1 / fireRate;
            }
            fireCountdown *= Time.deltaTime;
        }
    }
    void Shoot()
    {
        Debug.Log("PAN PAN");
        GameObject bulletChase=(GameObject)Instantiate(ShootPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletChase.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Chase(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
