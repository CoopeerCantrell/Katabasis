using System.Collections;
using UnityEngine;

public class Heracles : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerMovement;
    public Rigidbody2D rb;
    public bool alive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        rb = player.GetComponent<Rigidbody2D>();
        playerMovement.fallSpeed = 50f;
        playerMovement.cantBeHit = true;
        playerMovement.thrown = true;
        rb.gravityScale = 25;
        StartCoroutine(Wait1Sec());
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == false)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Wait1Sec()
    {
        alive = true;
        yield return new WaitForSeconds(1);
        alive = false;
    }
}
