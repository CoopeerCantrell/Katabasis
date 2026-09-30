using System.Collections.Generic;
using UnityEngine;

public class NextSection : MonoBehaviour
{
    public List<ModifierObject> mods;
    public List<ModifierObject> copiedMods;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Shuffle(List<ModifierObject> strings, List<ModifierObject> tempwords)
    {
        List<ModifierObject> temp = new List<ModifierObject>();
        temp.AddRange(strings);

        for (int i = 0; i < strings.Count; i++)
        {
            int index = Random.Range(0, temp.Count - 1);
            tempwords.Add(temp[index]);
            temp.RemoveAt(index);
        }
    }
}
