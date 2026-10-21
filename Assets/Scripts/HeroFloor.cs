using UnityEngine;

public class HeroFloor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            if (player.GetComponent<PlayerMovement>().thrown)
            {
                player.GetComponent<PlayerMovement>().thrown = false;
                player.GetComponent<PlayerMovement>().cantBeHit = false;
                player.GetComponent<Rigidbody2D>().gravityScale = 2;
            }
        }
    }
}
