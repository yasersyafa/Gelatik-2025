using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Food_Menu;

public class FoodMenu : IGameState
{
    public TutorialState _tutorial { get; private set; }
    public StartState _start { get; private set; }
    public WinState _win { get; private set; }

    private IGameState _currentSubState;

    // constructor
    public FoodMenu()
    {
        // register all sub state in FoodMenu state
        _tutorial = new();
        _start = new();
        _win = new();
    }

    public void Enter(StateManager state)
    {
        _currentSubState = _tutorial;
        _currentSubState?.Enter(state);
    }

    public void Execute(StateManager state)
    {
        _currentSubState?.Execute(state);
    }

    public void Exit(StateManager state)
    {
        _currentSubState?.Exit(state);
    }

    public void ChangeSubState(IGameState newSubState, StateManager state)
    {
        _currentSubState?.Exit(state);
        _currentSubState = newSubState;
        _currentSubState?.Enter(state);
    }
}
