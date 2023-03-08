using System;
using UnityEngine;

namespace Objects.Characters
{
    public class Player : Killable
    {
        [SerializeField] private int maxHealth;

        private int _currentMaxHealth;
        public int CurrentMaxHealth
        {
            get => _currentMaxHealth;
            set
            {
                if (value < _currentMaxHealth)
                {
                    DealDamage(_currentMaxHealth - value);
                }

                _currentMaxHealth = value;
            }
        }

        private void Awake()
        {
            CurrentMaxHealth = maxHealth;
        }
    }
}
