using UnityEngine;
using UnityEngine.Rendering;

public class HandMinotaur : MonoBehaviour
{
    public GameObject minoPrefab;
    public GameObject player;
    Vector3 sprearSpawn;
    public float throwforce = 20f;
    public bool handRight = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().movement.x > 0)
        {
            sprearSpawn = new Vector3(player.transform.position.x - 15, player.transform.position.y - 18, player.transform.position.z);
            handRight = true;
        }
        else if (player.GetComponent<PlayerMovement>().movement.x < 0)
        {
            sprearSpawn = new Vector3(player.transform.position.x + 15, player.transform.position.y - 18, player.transform.position.z);
            handRight = false;
        }
        else
        {
            sprearSpawn = new Vector3(player.transform.position.x - 35, player.transform.position.y - 18, player.transform.position.z);
            handRight = true;
        }
    }

    public void Use()
    {
        GameObject spear = Instantiate(minoPrefab, sprearSpawn, player.transform.rotation);
        if (handRight)
        {
            spear.GetComponent<Minotaur>().right = true;
        }
        else
        {
            spear.GetComponent<Minotaur>().right = false;
        }

        Inventory.instance.ConsumeEquippedItem();
        Destroy(gameObject);
    }
}
