using UnityEngine;
using UnityEngine.Events;

namespace Objects.Characters
{
    public class Killable : MonoBehaviour
    {
        public delegate void OnChangeHealth(int newHealth);

        [SerializeField] private int initialHealth;
        public UnityEvent onDeath;

        private int _currentHealthPoints;

        public OnChangeHealth OnChangeHealthEvent;

        private int CurrentHealthPoints
        {
            get => _currentHealthPoints;
            set
            {
                if (value <= 0)
                {
                    onDeath?.Invoke();
                    value = 0;
                }

                OnChangeHealthEvent?.Invoke(value);
                _currentHealthPoints = value;
            }
        }

        private void Start()
        {
            CurrentHealthPoints = initialHealth;
        }

        public void DealDamage(int hpToDecrease)
        {
            CurrentHealthPoints -= hpToDecrease;
        }
    }
}