using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D body;
    public float speed = 5f;
    Vector2 movement;
    public int lifeAmount = 1;
    public GameObject deathPanel;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        body.linearVelocity = new Vector2(movement.x * speed, body.linearVelocity.y);

        if (lifeAmount == 0)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
