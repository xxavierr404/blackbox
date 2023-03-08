using Objects.Characters;
using UnityEngine;
using UnityEngine.AI;

public class Freezable : MonoBehaviour
{
    [SerializeField] private float maxFreezeRate;
    [SerializeField] private float freezeDuration;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private new MeshRenderer renderer;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Enemy attacker;

    private float _currentFreezeRate;
    private float CurrentFreezeRate
    {
        get => _currentFreezeRate;
        set
        {
            if (value == 0)
            {
                Unfreeze();
            }

            if (value >= maxFreezeRate)
            {
                Freeze();
            }
            
            if (renderer)
            {
                if (value == 0)
                {
                    renderer.material.color = _initialColor;
                }
                else
                {
                    var freezeRate = Mathf.Clamp(value, 0, maxFreezeRate);
                    var material = renderer.material;
                    var oldColor = material.color;
                    material.color = new Color(
                        oldColor.r * (maxFreezeRate - freezeRate) / maxFreezeRate,
                        oldColor.g * (maxFreezeRate - freezeRate) / maxFreezeRate,
                        freezeRate / maxFreezeRate);
                }
            }

            _currentFreezeRate = value;
        }
    }
    private float _timeUntilUnfreezing;
    private bool _frozen;
    private Color _initialColor;
    
    private void Start()
    {
        _initialColor = renderer.material.color;
    }

    private void FixedUpdate()
    {
        if (_timeUntilUnfreezing > 0)
        {
            _timeUntilUnfreezing -= Time.deltaTime;
        }
        else
        {
            ResetFreezeRate();
        }
    }

    public void ResetFreezeRate()
    {
        CurrentFreezeRate = 0;
    }
    
    public void IncreaseFreezeRate(float freezeRate)
    {
        _timeUntilUnfreezing = freezeDuration;
        CurrentFreezeRate += freezeRate;
    }

    private void Freeze()
    {
        if (_frozen)
        {
            return;
        }
        
        _frozen = true;
        rb.isKinematic = true;

        if (navMeshAgent)
        {
            navMeshAgent.isStopped = true;
        }

        if (attacker)
        {
            attacker.enabled = false;
        }
        
        _timeUntilUnfreezing = freezeDuration;
    }

    private void Unfreeze()
    {
        rb.isKinematic = false;

        if (navMeshAgent)
        {
            navMeshAgent.isStopped = false;
        }

        if (attacker)
        {
            attacker.enabled = true;
        }

        _frozen = false;
    }
}