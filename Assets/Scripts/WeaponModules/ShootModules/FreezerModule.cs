using UnityEngine;

namespace WeaponModules.ShootModules
{
    [CreateAssetMenu(fileName = "FreezerModule", menuName = "Shoot Modules/Freezer module")]
    public class FreezerModule : ShootModule
    {
        [SerializeField] private float shootDistance;
        [SerializeField] private float freezePower;
        
        public override void Shoot(Transform shooter)
        {
            RaycastHit hit;
            Physics.Raycast(shooter.position, shooter.forward, out hit, shootDistance);
            hit.collider.GetComponent<Freezable>().IncreaseFreezeRate(freezePower);
        }
    }
}