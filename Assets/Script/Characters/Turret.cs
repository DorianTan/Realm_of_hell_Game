using UnityEngine;

public class Turret : MonoBehaviour
{

    private Animator animator;
    private Transform target;
    private float angle;
    private float fireCountdown = 0f;
    private Hammer hammer;
   
    
    public float range;
    public string enemyTag = "Enemy";
    public float fireRate = 1f;
    public GameObject ShootPrefab;
    public GameObject HammerPrefab; 
    public Transform firePoint;
    public So_Turret SO_Turret;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        animator = GetComponent<Animator>();
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
        
        if (fireCountdown<=0)
        {
            switch (this.tag)
            {
                case "turret_Shoot":      
                {
                    Shoot();
                    animator.SetTrigger("Shoot");
                    fireCountdown = 1f / fireRate;
                        break;
                }
                case "turret_HTH":
                {
                    HammerDown();
                    animator.SetTrigger("Hit");
                    GetComponent<AudioSource>().Play();
                    fireCountdown = 1 / fireRate;
                    break;
                }
                case "turret_Stop":
                {
                    animator.SetTrigger("Hit");
                    GetComponent<AudioSource>().Play();
                    fireCountdown = 1 / fireRate;
                    target.GetComponent<Enemy>().speed = 0;
                    break;
                }
            }
        }
        fireCountdown -= Time.deltaTime;
    }

    void HammerDown()
    {     
        HammerPrefab.GetComponent<Hammer>().damages = SO_Turret.Damage;
    }

    void Shoot()
    {
        Debug.Log("PAN PAN");
        GameObject bulletChase=(GameObject)Instantiate(ShootPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletChase.GetComponent<Bullet>();
        bullet.damages = SO_Turret.Damage;

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
