using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;

    public float speed=10f;
    public float startHealth = 100;
    public float health;   
    public Image healthBar;
    public int EnemyMoney = 20;

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
        if (healthBar.fillAmount <= 0) 
        {
             Die();
        }
    }

    void Die()
    {
        PlayerStat.Money += EnemyMoney;
        Destroy(gameObject);
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

	    if (speed == 0)
	    {
	        StartCoroutine(Waiting());	        
	    }
	}

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2f);
        speed = 3f;
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
