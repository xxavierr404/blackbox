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
            RaycastHit hit;
            Physics.Raycast(shooter.position, shooter.forward, out hit, shootDistance);
            
            if (!hit.collider)
            {
                return;
            }
            
            var freezable = hit.collider.GetComponent<Freezable>();
            if (!freezable)
            {
                return;
            }
            
            freezable.IncreaseFreezeRate(freezePower);
        }
    }
}