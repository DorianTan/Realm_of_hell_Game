using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public float speed=10f;
    private Transform target;
    private int wavepointIndex = 0;



	// Use this for initialization
	void Start ()
	{
	    target = WayPoints.wayPoints[0];    
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
        if (wavepointIndex >= WayPoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            return;

        }
        wavepointIndex++;
        transform.position = target.position;               //remet l'ennemie sur waypoint pour pas qu'il parte en diagonale
        target = WayPoints.wayPoints[wavepointIndex];
        
    }
}
