using System;
using UnityEngine;

namespace WeaponModules.ShootModules
{
    public class GenericProjectileModule : ShootModule
    {
        [SerializeField] private String prefabName;
        [SerializeField] private float shootingForce;
        [SerializeField] private float shootDelay;

        private float _delay;
        private UnityEngine.Object _bulletPrefab;

        private void Start()
        {
            _delay = 0;
            _bulletPrefab = Resources.Load(prefabName);
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
            var bulletInstance = Instantiate(_bulletPrefab,
                transform.position, 
                transform.rotation, 
                null) as GameObject;
            bulletInstance.GetComponent<Rigidbody>().AddForce(shooter.forward * shootingForce, 
                ForceMode.Impulse);
            _delay = shootDelay;
        }
    }
}