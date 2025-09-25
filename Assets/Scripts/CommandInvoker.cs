using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandInvoker
{
    private static Stack<Command> _undoStack = new Stack<Command>();
    private static Stack<Command> _redoStack = new Stack<Command>();

    public static void ExecuteCommand(Command command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
    }

    public static void UndoCommand()
    {
        if (_undoStack.Count > 0)
        {
            Command activeCommand = _undoStack.Pop();
            _redoStack.Push(activeCommand);
            activeCommand.Undo();
        }
    }

    public static void RedoCommand()
    {
        if (_redoStack.Count > 0)
        {
            Command activeCommand = _redoStack.Pop();
            _undoStack.Push(activeCommand);
            activeCommand.Execute();
        }
    }
}
