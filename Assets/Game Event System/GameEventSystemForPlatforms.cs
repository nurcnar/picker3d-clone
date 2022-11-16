using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEventSystemForPlatforms : MonoBehaviour
{
    public static GameEventSystemForPlatforms instance;
    private void Awake()
    {
        instance = this;
    }

    public event Action High;
    public void Rise()
    {
        High?.Invoke();
    }
}
