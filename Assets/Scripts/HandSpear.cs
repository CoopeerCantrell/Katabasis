using UnityEngine;

public class HandSpear : MonoBehaviour
{
    public GameObject spearPrefab;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use()
    {
        Instantiate(spearPrefab, player.transform.position, player.transform.rotation);
        Inventory.instance.ConsumeEquippedItem();
        Destroy(gameObject);
    }
}
