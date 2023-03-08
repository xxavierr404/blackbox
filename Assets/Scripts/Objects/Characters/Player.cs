using Controllers;
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
                if (value < _currentMaxHealth) DealDamage(_currentMaxHealth - value);

                _currentMaxHealth = value;
            }
        }

        private void Awake()
        {
            onDeath.AddListener(Die);
            CurrentMaxHealth = maxHealth;
        }

        private void Die()
        {
            Destroy(GetComponent<PlayerController>());
            Destroy(Camera.main.GetComponent<CameraController>());
        }
    }
}