using UnityEngine;

namespace Objects.Projectiles
{
    public class WaterDrop : MonoBehaviour
    {
        [SerializeField] private float timeUntilEvaporation;

        private float _timeLeft;
        private bool _evaporating;

        private void Awake()
        {
            _evaporating = true;
            _timeLeft = timeUntilEvaporation;
        }

        private void Update()
        {
            if (_timeLeft <= 0)
            {
                Destroy(gameObject);
            }

            if (_evaporating)
            {
                _timeLeft -= Time.deltaTime;
            }
        }

        public void StartEvaporation()
        {
            _evaporating = true;
        }

        public void StopEvaporation()
        {
            _evaporating = false;
        }
    }
}