using UnityEngine;

namespace Objects.Projectiles
{
    public class WaterDrop : MonoBehaviour
    {
        [SerializeField] private float timeUntilEvaporation;
        private bool _evaporating;

        private float _timeLeft;

        private void Awake()
        {
            _evaporating = true;
            _timeLeft = timeUntilEvaporation;
        }

        private void Update()
        {
            if (_timeLeft <= 0) Destroy(gameObject);

            if (_evaporating) _timeLeft -= Time.deltaTime;
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