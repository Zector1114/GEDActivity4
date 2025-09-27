using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandInvoker
{
    private Stack<Command> _undoStack;
    private Stack<Command> _redoStack;

    public CommandInvoker()
    {
        _undoStack = new Stack<Command>();
        _redoStack = new Stack<Command>();
    }

    public void ExecuteCommand(Command command)
    {
        _undoStack.Push(command);
        _redoStack.Clear();
        command.Execute();
    }

    public void UndoCommand()
    {
        if (_undoStack.Count > 0)
        {
            Command activeCommand = _undoStack.Pop();
            _redoStack.Push(activeCommand);
            activeCommand.Undo();
        }
    }

    public void RedoCommand()
    {
        if (_redoStack.Count > 0)
        {
            Command activeCommand = _redoStack.Pop();
            _undoStack.Push(activeCommand);
            activeCommand.Execute();
        }
    }

    public void ClearCommand()
    {
        _undoStack.Clear();
        _redoStack.Clear();
    }
}
