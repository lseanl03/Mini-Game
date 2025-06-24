using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager 
{
    public static Action OnNPCCollisionExit;
    
    public static Action OnNPCCollisionEnter;

    public static Action<SceneType> OnSceneChanged;

    public static Action OnEnemyDied;
}
