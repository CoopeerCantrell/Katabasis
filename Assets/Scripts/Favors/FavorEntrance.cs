using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FavorEntrance : MonoBehaviour
{
    public GameObject favorUi;
    public bool inFavor = false;
    public DialogInteraction dialogInteraction;
    public Dialogue dialogue;
    public DialogGraph chosenHero;
    public List<DialogGraph> dialogGraphs;
    public List<DialogGraph> tempGraphs = new List<DialogGraph>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        favorUi = FindInactiveObject("FavorUI");
        dialogue = gameObject.GetComponent<Dialogue>();
        tempGraphs = new List<DialogGraph>();
        Shuffle(dialogGraphs, tempGraphs);
        
        //Shuffle(dialogGraphs, tempGraphs);
        chosenHero = GetWord();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Shuffle(List<DialogGraph> strings, List<DialogGraph> tempwords)
    {
        List<DialogGraph> temp = new List<DialogGraph>();
        temp.AddRange(strings);

        for (int i = 0; i < strings.Count; i++)
        {
            int index = Random.Range(0, temp.Count);
            tempwords.Add(temp[index]);
            temp.RemoveAt(index);
        }
    }

    public DialogGraph GetWord()
    {
        DialogGraph newWord = null;

        if (tempGraphs.Count != 0)
        {
            newWord = tempGraphs[0];
            tempGraphs.Remove(tempGraphs[0]);
        }
        return newWord;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogue.SetDialogGraph(chosenHero);
            dialogInteraction.StartDiologue(gameObject.GetComponent<FavorEntrance>());
            favorUi.SetActive(true);
            Time.timeScale = 0f;
            pauseMenu.GameIsPaused = true;
            inFavor = true;
        }
    }

    public void LeaveFavor()
    {
        favorUi.SetActive(false);
        Time.timeScale = 1f;
        pauseMenu.GameIsPaused = false;
        inFavor = false;
    }
}
