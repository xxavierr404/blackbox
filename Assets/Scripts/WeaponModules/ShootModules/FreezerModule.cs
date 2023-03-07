using UnityEngine;

namespace WeaponModules.ShootModules
{
    public class FreezerModule : ShootModule
    {
        [SerializeField] private float shootDistance;
        [SerializeField] private float freezePower;

        public override void Shoot(Transform shooter)
        {
            base.Shoot(shooter);
            
            Physics.Raycast(transform.position, shooter.forward, out var hit, shootDistance);
            
            if (!hit.collider)
            {
                return;
            }
            
            var freezable = hit.collider.GetComponent<Freezable>();
            if (freezable)
            {
                freezable.IncreaseFreezeRate(freezePower * Time.deltaTime);
            }
        }
    }
}