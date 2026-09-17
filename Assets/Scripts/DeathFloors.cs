using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFloors : MonoBehaviour
{
    public GameObject deathPanel;
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
        if (collision.CompareTag("Player")){
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
}
