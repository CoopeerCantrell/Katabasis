using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

[DisallowMultipleComponent]
public class CommendPattern : MonoBehaviour
{
    public float maoveDistnce = 1.0f;
    private readonly Stack<ICommand> commandhistory = new Stack<ICommand>();
    public int UndoCount = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            ExecuteMoveCommand(Vector3.up * maoveDistnce);
        if (Input.GetKeyDown(KeyCode.A))
            ExecuteMoveCommand(Vector3.left * maoveDistnce);
        if (Input.GetKeyDown(KeyCode.S))
            ExecuteMoveCommand(Vector3.up * -maoveDistnce);
        if (Input.GetKeyDown(KeyCode.D))
            ExecuteMoveCommand(Vector3.right * maoveDistnce);

        if (Input.GetKeyDown(KeyCode.Space))
            Undo();

        if (Input.GetKeyDown(KeyCode.P))
        {
            ScoreManager.instance.AddScore(23f);
        }
    }

    public void Undo()
    {
        if (commandhistory.Count == 0)
            return;
        ICommand command = commandhistory.Pop();
        command.Undo();
        UndoCount--;
    }

    void ExecuteMoveCommand(Vector3 _amount) {
        ICommand command = new MoveCommand(transform, _amount);
        command.Execute();
        commandhistory.Push(command);
        UndoCount++;
    }
}

public interface ICommand
{
    void Execute();
    void Undo();

}

public class MoveCommand : ICommand
{

    private readonly Action execute;

    private readonly Action undo;

    private Vector3 startingPos;

    public MoveCommand(Transform _transform, Vector3 _moveAmount)
    {
        execute = () =>
        {
            startingPos = _transform.position;
            _transform.position += _moveAmount;
        };

        undo = () => _transform.position = startingPos;
    }

    public void Execute()
    {
        execute();
    }

    public void Undo()
    {
        undo();
    }
}

#if UNITY_EDITOR

#endif
