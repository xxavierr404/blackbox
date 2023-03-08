using System.Collections;
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
        [SerializeField] private Animator animator;

        private EnemyState _state;
        private float _timeUntilAttack;

        private void Awake()
        {
            onDeath.AddListener(() => Destroy(gameObject));
            if (!target)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Killable>();
            }
        }

        private void Update()
        {
            var distance = (target.transform.position - transform.position).magnitude;
            switch (_state)
            {
                default:
                case EnemyState.Idle:
                    CheckIfTargetIsNear(distance);
                    if (animator)
                        animator.SetTrigger("IsIdle");
                    break;
                case EnemyState.Chasing:
                    ChaseTarget(distance);
                    if (animator)
                        animator.SetTrigger("IsWalking");
                    break;
                case EnemyState.Attacking:
                    AttackTarget(distance);
                    if (animator)
                        animator.SetTrigger("IsAttacking");
                    break;
                case EnemyState.Disabled:
                    if (animator)
                        animator.SetTrigger("IsIdle");
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
                _state = EnemyState.Attacking;
            else if (distance > detectionDistance) _state = EnemyState.Idle;
        }

        private void CheckIfTargetIsNear(float distance)
        {
            if (distance <= detectionDistance) _state = EnemyState.Chasing;
        }

        public void DisableForSeconds(float seconds)
        {
            if (_state == EnemyState.Disabled) return;

            _state = EnemyState.Disabled;
            StartCoroutine(WaitBeforeEnabling(seconds));
        }

        private IEnumerator WaitBeforeEnabling(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            _state = EnemyState.Idle;
        }

        private enum EnemyState
        {
            Idle,
            Chasing,
            Attacking,
            Disabled
        }
    }
}