using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicEnemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rd;
    private Transform currentPoint;
    public float speed;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform) {
            rd.linearVelocity = new Vector2(-speed, 0);
        }
        else {
            rd.linearVelocity = new Vector2(speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform) {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform) {
            currentPoint = pointB.transform;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SceneManager.LoadScene("SampleScene");
    } 

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
    }
}
