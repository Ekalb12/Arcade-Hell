using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents
{
    public static Action OnGameStart;
    public static Action OnGameOver;
    public static Action OnGameRestart;
    public static Action<int> OnGameTimerCountDown;
    public static Action<int> OngameScore;
    public static Action<int> OnDamageTaken;
    public static Action OnGameLostFinal;
}
    
