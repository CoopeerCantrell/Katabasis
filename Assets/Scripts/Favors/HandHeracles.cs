using UnityEngine;

public class HandHeracles : MonoBehaviour
{
    public GameObject heraclesPrefab;
    public GameObject player;
    Vector3 sprearSpawn;
    public float throwforce = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        sprearSpawn = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
    }

    public void Use()
    {
       GameObject spear = Instantiate(heraclesPrefab, sprearSpawn, player.transform.rotation);
        Rigidbody2D rb = spear.GetComponent<Rigidbody2D>();

        spear.GetComponent<Heracles>().player = player;
        Inventory.instance.ConsumeEquippedItem();
        Destroy(gameObject);
    }
}
