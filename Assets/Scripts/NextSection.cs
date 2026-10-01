using System.Collections.Generic;
using UnityEngine;

public class NextSection : MonoBehaviour
{
    public SceneTransistion scene;
    public GameObject ModPaanels;
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
        if (collision.CompareTag("Player"))
        {
            ModPaanels.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
}
