using UnityEngine;

public class AddItem : MonoBehaviour
{
    public Inventory inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UseAddItem(ItemSO item)
    {
        inventory.AddItem(item, 1);
    }
}
