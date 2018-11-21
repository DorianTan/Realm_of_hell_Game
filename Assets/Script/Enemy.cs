﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    public float speed=10f;
    public float startHealth = 100;
    public float health;
    private Transform target;
    private int wavepointIndex = 0;

    public Image healthBar;


	// Use this for initialization
	void Start ()
	{
	    target = WayPoints.wayPoints[0];
        health = startHealth;
	}

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health/startHealth;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized*speed*Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.1f) //la distance des waypoints pour envoyer l'ennemie au prochain waypoints
        {
            GoNextWayPoint();
        }
    }

    void GoNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.wayPoints.Length - 1) //si il arrive au dernier, il se détruit
        {
            EndPath();
            return;

        }
        wavepointIndex++;
        transform.position = target.position;               //remet l'ennemie sur waypoint pour pas qu'il parte en diagonale
        target = WayPoints.wayPoints[wavepointIndex];
        
    }

    void EndPath()
    {
        PlayerStat.Lives--;
        Destroy(gameObject);
    }
}
