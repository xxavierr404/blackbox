using System;
using UnityEngine;

public class Freezable : MonoBehaviour
{
    [SerializeField] private float maxFreezeRate;
    [SerializeField] private float freezeDuration;
    [SerializeField] private Rigidbody rb;

    private float _currentFreezeRate;
    private float _timePassed;
    
    private void Start()
    {
        ResetFreezeRate();
    }

    private void FixedUpdate()
    {
        if (_timePassed < freezeDuration)
        {
            _timePassed += Time.deltaTime;
        }
        else
        {
            ResetFreezeRate();
        }
    }

    public void ResetFreezeRate()
    {
        _currentFreezeRate = 0;
        Unfreeze();
    }
    
    public void IncreaseFreezeRate(float freezeRate)
    {
        _timePassed = 0;
        _currentFreezeRate += freezeRate;
        if (_currentFreezeRate >= maxFreezeRate)
        {
            Freeze();
        }
    }

    private void Freeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void Unfreeze()
    {
        rb.constraints = RigidbodyConstraints.None;
    }
}