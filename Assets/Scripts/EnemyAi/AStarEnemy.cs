using UnityEngine;
using Pathfinding;
using UnityEngine.Splines;
using NUnit.Framework.Constraints;
using UnityEditor.Callbacks;

public class AStarEnemy : MonoBehaviour
{

    public Transform target;

    public float speed = 30f;
    public float wayPointDist = 3f;
    public bool canHunt = false;
    public float radius = 2f;
    Collider2D[] hitColliders;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPoint = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.1f);
        
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPoint = true;
        }
        else
        {
            reachedEndOfPoint = false;
        }
        hitColliders = Physics2D.OverlapCircleAll(transform.position,radius);
        foreach (var hitCollider  in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                canHunt = true;
                Debug.Log(canHunt);
            }
        }


        if (canHunt)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < wayPointDist)
            {
                currentWaypoint++;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            if (player.GetComponent<PlayerMovement>().cantBeHit == false && player.GetComponent<PlayerMovement>().lifeAmount >= 2)
            {
                player.GetComponent<PlayerMovement>().lifeAmount--;
                player.GetComponent<PlayerMovement>().CallDamageTick();
            }
            else if (player.GetComponent<PlayerMovement>().cantBeHit == false)
            {
                player.GetComponent<PlayerMovement>().lifeAmount--;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
