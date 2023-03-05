using UnityEngine;

namespace WeaponModules
{
    public abstract class ShootModule: ScriptableObject
    {
        public abstract void Shoot(Transform shooter);
    }
}