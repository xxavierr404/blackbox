using UnityEngine;
using WeaponModules;

namespace Objects
{
    public class ModuleCollectible : MonoBehaviour
    {
        [SerializeField] private ShootModule shootModule;
        [SerializeField] private PassiveModule passiveModule;
        [SerializeField] private bool isPassive;

        public bool IsPassive => isPassive;
        public ShootModule ShootModule => shootModule;
        public PassiveModule PassiveModule => passiveModule;
    }
}