using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;

    public float range;

    public string enemyTag = "Enemy";

    private float angle;

    public float offset;

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
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
