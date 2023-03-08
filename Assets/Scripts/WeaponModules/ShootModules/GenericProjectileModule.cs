using UnityEngine;

namespace WeaponModules.ShootModules
{
    public class GenericProjectileModule : ShootModule
    {
        [SerializeField] private float shootingForce;
        [SerializeField] private GameObject _bulletPrefab;

        public override void Shoot(Transform shooter)
        {
            base.Shoot(shooter);
            if (!CanShoot) return;

            var weaponTransform = transform;
            var bulletInstance = Instantiate(_bulletPrefab,
                weaponTransform.position,
                weaponTransform.rotation,
                null);
            bulletInstance
                .GetComponent<Rigidbody>()
                .AddForce(
                    shooter.forward * shootingForce,
                    ForceMode.Impulse);
        }
    }
}