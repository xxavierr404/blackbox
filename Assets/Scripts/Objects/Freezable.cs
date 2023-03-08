using Objects.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace Objects
{
    public class Freezable : MonoBehaviour
    {
        [SerializeField] private float maxFreezeRate;
        [SerializeField] private float freezeDuration;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Enemy attacker;
        [SerializeField] private FreezableColorHandler colorHandler;

        private float _currentFreezeRate;
        private bool _frozen;
        private float _timeUntilUnfreezing;

        private float CurrentFreezeRate
        {
            get => _currentFreezeRate;
            set
            {
                if (value == 0) Unfreeze();

                if (value >= maxFreezeRate) Freeze();

                if (colorHandler)
                {
                    colorHandler.UpdateColor(value, maxFreezeRate);   
                }

                _currentFreezeRate = value;
            }
        }
        
        private void FixedUpdate()
        {
            if (_timeUntilUnfreezing > 0)
                _timeUntilUnfreezing -= Time.deltaTime;
            else
                ResetFreezeRate();
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
            if (_frozen) return;

            _frozen = true;
            rb.isKinematic = true;

            if (navMeshAgent) navMeshAgent.isStopped = true;

            if (attacker) attacker.enabled = false;

            _timeUntilUnfreezing = freezeDuration;
        }

        private void Unfreeze()
        {
            rb.isKinematic = false;

            if (navMeshAgent) navMeshAgent.isStopped = false;

            if (attacker) attacker.enabled = true;

            _frozen = false;
        }
    }
}