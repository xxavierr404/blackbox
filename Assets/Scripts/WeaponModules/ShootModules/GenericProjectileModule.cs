using System;
using UnityEngine;

namespace WeaponModules.ShootModules
{
    public class GenericProjectileModule : ShootModule
    {
        [SerializeField] private String prefabName;
        [SerializeField] private float shootingForce;

        private UnityEngine.Object _bulletPrefab;

        private void Start()
        {
            _bulletPrefab = Resources.Load(prefabName);
        }

        public override void Shoot(Transform shooter)
        {
            base.Shoot(shooter);
            if (!CanShoot)
            {
                return;
            }

            var weaponTransform = transform;
            var bulletInstance = Instantiate(_bulletPrefab,
                weaponTransform.position, 
                weaponTransform.rotation, 
                null) as GameObject;
            bulletInstance.GetComponent<Rigidbody>().AddForce(shooter.forward * shootingForce, 
                ForceMode.Impulse);
        }
    }
}