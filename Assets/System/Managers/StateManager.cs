using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public IGameState _currentState;
    // Start is called before the first frame update
    void Start()
    {
        _currentState?.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState?.Execute(this);
    }

    public void ChangeState(IGameState newState)
    {
        _currentState?.Exit(this);
        _currentState = newState;
        _currentState?.Enter(this);
    }
}
