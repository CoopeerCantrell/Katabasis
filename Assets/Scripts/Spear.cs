using UnityEngine;

public class Spear : MonoBehaviour
{
    public GameObject spearPrefab;
    public GameObject player;
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
        if (collision.tag == "Enemy")
        {
            Destroy(collision);
        }
        else if (collision.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
