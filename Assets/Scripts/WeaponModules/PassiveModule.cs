using Controllers;
using UnityEngine;

namespace WeaponModules
{
    public abstract class PassiveModule : ScriptableObject
    {
        [SerializeField] private string moduleName;
        public string ModuleName => moduleName;

        public abstract void ApplyBuff(PlayerController playerController);
        public abstract void RevertBuff(PlayerController player);
    }
}