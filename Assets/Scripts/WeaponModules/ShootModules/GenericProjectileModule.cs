using System;
using UnityEngine;

namespace WeaponModules.ShootModules
{
    public class GenericProjectileModule : ShootModule
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private float shootingForce;
        [SerializeField] private float shootDelay;

        private float _delay;

        private void Start()
        {
            _delay = 0;
        }

        private void Update()
        {
            if (_delay > 0)
            {
                _delay -= Time.deltaTime;
            }
        }

        public override void Shoot(Transform shooter)
        {
            if (_delay > 0)
            {
                return;
            }

            base.Shoot(shooter);
            var bulletInstance = Instantiate(bullet, shooter.position, shooter.rotation, null);
            bulletInstance.GetComponent<Rigidbody>().AddForce(shooter.forward * shootingForce, 
                ForceMode.Impulse);
            _delay = shootDelay;
        }
    }
}