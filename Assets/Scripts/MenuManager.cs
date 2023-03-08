using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance;
    
    public delegate void OnMenuStateChange(bool newState);

    public OnMenuStateChange OnMenuStateChangeEvent;

    private void Awake()
    {
        _instance = this;
    }

    public static MenuManager GetInstance()
    {
        return _instance;
    }
}