using System.Collections.Generic;
using UnityEngine;

public class NextSection : MonoBehaviour
{
    public SceneTransistion scene;
    public GameObject ModPaanels;
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ModPaanels = FindInactiveObject("ModPanel");
        scene = GameObject.FindGameObjectWithTag("Inventory").GetComponent<SceneTransistion>();
        audioSource = GameObject.FindGameObjectWithTag("Inventory").GetComponent<AudioSource>();
    }
    GameObject FindInactiveObject(string name)
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in objects)
        {
            if (obj.name == name && obj.scene.IsValid())
            {
                return obj;
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioClip);
            ModPaanels.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
}
