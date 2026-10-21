using UnityEngine;

public class Minotaur : MonoBehaviour
{
    public float speed = 8f;
    public bool right = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            Debug.Log("should destroy enemy");
            Destroy(collision.gameObject);
        }
    }
}
