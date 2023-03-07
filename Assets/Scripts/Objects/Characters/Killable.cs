using System;
using UnityEngine;

namespace Objects.Characters
{
    public class Killable : MonoBehaviour
    {
        [SerializeField] private int healthPoints;

        private int _currentHealthPoints;
        private int CurrentHealthPoints
        {
            get => _currentHealthPoints;
            set
            {
                if (value <= 0)
                {
                    Destroy(gameObject);
                }

                _currentHealthPoints = value;
            }
        }

        private void Start()
        {
            _currentHealthPoints = healthPoints;
        }

        public void DealDamage(int hpToDecrease)
        {
            CurrentHealthPoints -= hpToDecrease;
        }
    }
}