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
            Debug.DrawRay(shooter.position, shooter.forward * 3f, Color.red);
            hit.collider.GetComponent<Freezable>().IncreaseFreezeRate(freezePower);
        }
    }
}