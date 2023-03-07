using System;
using UnityEngine;
using UnityEngine.AI;

namespace Objects.Characters
{
    public class Enemy : Killable
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Killable target;
        [SerializeField] private float detectionDistance;
        [SerializeField] private float attackDistance;
        [SerializeField] private float attackDelay;
        [SerializeField] private int damage;

        private enum EnemyState
        {
            Idle,
            Chasing,
            Attacking
        }

        private EnemyState _state;
        private float _timeUntilAttack;

        private void Awake()
        {
            onDeath.AddListener(() => Destroy(gameObject));
        }

        private void Update()
        {
            var distance = (target.transform.position - transform.position).magnitude;
            switch (_state)
            {
                default:
                case EnemyState.Idle:
                    CheckIfTargetIsNear(distance);
                    break;
                case EnemyState.Chasing:
                    ChaseTarget(distance);
                    break;
                case EnemyState.Attacking:
                    AttackTarget(distance);
                    break;
            }
            
        }

        private void AttackTarget(float distance)
        {
            if (distance > attackDistance)
            {
                _state = EnemyState.Chasing;
                return;
            }

            if (_timeUntilAttack <= 0)
            {
                target.DealDamage(damage);
                _timeUntilAttack = attackDelay;
            }
            else
            {
                _timeUntilAttack -= Time.deltaTime;
            }
        }

        private void ChaseTarget(float distance)
        {
            navMeshAgent.destination = target.transform.position;

            if (distance <= attackDistance)
            {
                _state = EnemyState.Attacking;
            }
            else if (distance > detectionDistance)
            {
                _state = EnemyState.Idle;
            }
        }

        private void CheckIfTargetIsNear(float distance)
        {
            if (distance <= detectionDistance)
            {
                _state = EnemyState.Chasing;
            }
        }
    }
}
