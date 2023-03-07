using System;
using UnityEngine;
using UnityEngine.AI;

public class Freezable : MonoBehaviour
{
    [SerializeField] private float maxFreezeRate;
    [SerializeField] private float freezeDuration;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private new MeshRenderer renderer;
    [SerializeField] private NavMeshAgent navMeshAgent;

    private float _currentFreezeRate;
    private float CurrentFreezeRate
    {
        get => _currentFreezeRate;
        set
        {
            if (renderer)
            {
                if (value == 0)
                {
                    renderer.material.color = _initialColor;
                }
                else
                {
                    var material = renderer.material;
                    var oldColor = material.color;
                    material.color = new Color(
                        oldColor.r * (maxFreezeRate - value) / maxFreezeRate,
                        oldColor.g * (maxFreezeRate - value) / maxFreezeRate,
                        value / maxFreezeRate * 255);
                }
            }

            _currentFreezeRate = value;
        }
    }
    private float _timePassed;
    private bool _frozen;
    private Color _initialColor;
    
    private void Start()
    {
        _initialColor = renderer.material.color;
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
        CurrentFreezeRate = 0;
        Unfreeze();
    }
    
    public void IncreaseFreezeRate(float freezeRate)
    {
        _timePassed = 0;
        CurrentFreezeRate += freezeRate;
        if (CurrentFreezeRate >= maxFreezeRate && !_frozen)
        {
            Freeze();
        }
    }

    private void Freeze()
    {
        Debug.Log("Frozen");
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.velocity = Vector3.zero;

        if (navMeshAgent)
        {
            navMeshAgent.isStopped = true;
        }

        _frozen = true;
    }

    private void Unfreeze()
    {
        rb.constraints = RigidbodyConstraints.None;

        if (navMeshAgent)
        {
            navMeshAgent.isStopped = false;
        }

        _frozen = false;
    }
}