using UnityEngine;
using UnityEngine.Events;

namespace Objects.Characters
{
    public class Killable : MonoBehaviour
    {
        [SerializeField] private int initialHealth;
        public UnityEvent onDeath;
        
        private int _currentHealthPoints;
        
        protected int CurrentHealthPoints
        {
            get => _currentHealthPoints;
            set
            {
                if (value <= 0)
                {
                    onDeath?.Invoke();
                    value = 0;
                }

                _currentHealthPoints = value;
            }
        }

        private void Start()
        {
            _currentHealthPoints = initialHealth;
        }

        public void DealDamage(int hpToDecrease)
        {
            CurrentHealthPoints -= hpToDecrease;
        }
    }
}