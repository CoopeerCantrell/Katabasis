using System;
using UnityEngine;

[DisallowMultipleComponent]
public class CommendPattern : MonoBehaviour
{
    public float maoveDistnce = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public interface ICommand
{
    void Execute();
    void Undo();

}

public class MoveCommand : ICommand
{
    private readonly Action executeAction;
    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }
}
