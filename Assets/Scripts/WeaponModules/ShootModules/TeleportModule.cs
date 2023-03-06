using UnityEngine;

namespace WeaponModules.ShootModules
{
    public class TeleportModule : ShootModule
    {
        [SerializeField] private Transform teleportableTransform;
        
        public override void Shoot(Transform shooter)
        {
            base.Shoot(shooter);
            if (!CanShoot) return;

            RaycastHit hit;
            if (!Physics.Raycast(shooter.position, shooter.forward, out hit, 20f))
            {
                return;
            }

            teleportableTransform.position = hit.transform.position + Vector3.up;
        }
    }
}