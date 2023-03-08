using Controllers;
using UnityEngine;

namespace WeaponModules.PassiveModules
{
    [CreateAssetMenu(fileName = "SpeedIncrease", menuName = "Passive Modules/Speed increase")]
    public class SpeedIncreaseModule : PassiveModule
    {
        [SerializeField] private float newSpeed;

        public override void ApplyBuff(PlayerController playerController)
        {
            playerController.SetMovementSpeed(newSpeed);
        }

        public override void RevertBuff(PlayerController player)
        {
            player.ResetMovementSpeed();
        }
    }
}