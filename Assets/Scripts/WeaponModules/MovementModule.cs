using UnityEngine;

namespace WeaponModules
{
    public abstract class MovementModule: ScriptableObject
    {
        public abstract void ApplyBuff(PlayerController player);
        public abstract void RevertBuff(PlayerController player);
    }
}