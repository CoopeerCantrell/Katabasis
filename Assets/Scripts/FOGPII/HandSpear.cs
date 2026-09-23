using UnityEngine;

public class HandSpear : MonoBehaviour
{
    public GameObject spearPrefab;
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
        sprearSpawn = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z);
    }

    public void Use()
    {
       GameObject spear = Instantiate(spearPrefab, sprearSpawn, player.transform.rotation);
        Rigidbody2D rb = spear.GetComponent<Rigidbody2D>();
        
        Inventory.instance.ConsumeEquippedItem();
        Destroy(gameObject);
    }
}
