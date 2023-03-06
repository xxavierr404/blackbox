using Controllers;
using UnityEngine;

namespace WeaponModules
{
    public abstract class PassiveModule: ScriptableObject
    {
        public abstract void ApplyBuff(PlayerController player);
        public abstract void RevertBuff(PlayerController player);
    }
}