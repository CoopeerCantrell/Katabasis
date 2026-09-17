using UnityEngine;

public class Armor : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().lifeAmount++;
        Debug.Log("update life amount");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().lifeAmount == 1)
        {
            Inventory.instance.ConsumeEquippedItem();
            Destroy(gameObject);
        }
    }
}
