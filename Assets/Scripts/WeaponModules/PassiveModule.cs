using Controllers;
using UnityEngine;

namespace WeaponModules
{
    public abstract class PassiveModule: ScriptableObject
    {
        public abstract void ApplyBuff(PlayerController playerController);
        public abstract void RevertBuff(PlayerController player);
    }
}