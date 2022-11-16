using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class GameEventSystem : MonoBehaviour
{
    public int platformId;
    public int barrierId;
    public static GameEventSystem instance;
    private void Awake()
    {
        instance = this;
    }

    public event UnityAction<int> Platform;
    public void PlatformMovement(int platformId)
    {
        if(Platform!=null)
        {
            Platform?.Invoke(platformId);
        }
    }

    public event UnityAction<int> Barrier;
    public void BarrierOpening(int barrierId)
    {
        if(Barrier!=null)
        {
            Barrier?.Invoke(barrierId);
        }
    }

    
}
