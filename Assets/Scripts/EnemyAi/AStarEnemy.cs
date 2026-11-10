using UnityEngine;
using Pathfinding;


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
    float nextPathUpdateTime;
    const float PathUpdateInterval = 0.5f;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

    }

    void UpdatePath()
    {
        if (target != null && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
            nextPathUpdateTime = Time.time + PathUpdateInterval;
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
        else
        {
            Debug.LogWarning(p.errorLog);
        }
    }

    void FixedUpdate()
    {
        if (PauseMenu.GameIsPaused)
        {
            return;
        }

        hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                canHunt = true;
                if (target == null)
                {
                    target = hitCollider.transform;
                }
            }
        }

        if (path == null || Time.time >= nextPathUpdateTime)
        {
            UpdatePath();
        }

        if (!canHunt || target == null || path == null)
        {
            return;
        }

        // Skip reached waypoints, including the starting point at index zero.
        while (currentWaypoint < path.vectorPath.Count &&
               Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]) < wayPointDist)
        {
            currentWaypoint++;
        }

        // Keep the completed path intact while waiting for the next path update.
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;
        rb.AddForce(force);
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
