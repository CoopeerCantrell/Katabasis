using System.Collections.Generic;
using UnityEngine;

public class SectionPicker : MonoBehaviour
{
    public List<GameObject> sections;

    public List<GameObject> tempSections = new List<GameObject>();

    public GameObject theSection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Shuffle(sections,tempSections);
        Debug.Log(theSection);
    }
    void Start()
    {
        tempSections = new List<GameObject>();
        Shuffle(sections,tempSections);
        theSection = GetWord();
        Debug.Log(theSection);
        theSection = Instantiate(theSection);
    }

    // Update is called once per frame
    private void Shuffle(List<GameObject> strings, List<GameObject> tempwords)
    {
        List<GameObject> temp = new List<GameObject>();
        temp.AddRange(strings);

        for (int i = 0; i < strings.Count; i++)
        {
            int index = Random.Range(0, temp.Count - 1);
            tempwords.Add(temp[index]);
            temp.RemoveAt(index);
        }
    }

     public GameObject GetWord()
    {
        GameObject newWord = null;

        if (tempSections.Count != 0)
        {
            newWord = tempSections[0];
            tempSections.Remove(tempSections[0]);
        }
        return newWord;
    }
}
