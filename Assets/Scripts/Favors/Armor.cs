using System.Collections;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<PlayerMovement>().lifeAmount++;
        Debug.Log("update life amount");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Use()
    {
        player.GetComponent<PlayerMovement>().CallDamageTick();
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(107, 107, 107, 255);

        StartCoroutine(Wait3Sec());

        Inventory.instance.ConsumeEquippedItem();
        Destroy(gameObject);
    }

    IEnumerator Wait3Sec()
    {
        yield return new WaitForSeconds(3f);
    }
}
