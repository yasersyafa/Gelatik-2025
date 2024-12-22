using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    public void Enter(StateManager stateManager);
    public void Execute(StateManager stateManager);
    public void Exit(StateManager stateManager);
}
