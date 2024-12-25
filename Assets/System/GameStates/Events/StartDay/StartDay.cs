using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartDay : IGameState
{
    private GameObject Object;
    public void Enter(StateManager stateManager)
    {
        Object = GameObject.Find("Bars");
        GetStats();
    }

    public void Execute(StateManager stateManager)
    {
        
    }

    public void Exit(StateManager stateManager)
    {
        
    }

    private void GetStats()
    {
        GameManager manager = GameManager.Instance;
        Object.transform.DOLocalMoveY(0f, 1f, true).SetEase(Ease.InElastic).OnComplete(() => {
            manager.DecreaseStats();
        });
        
    }

}
