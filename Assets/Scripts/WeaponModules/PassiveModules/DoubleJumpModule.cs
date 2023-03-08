using Controllers;
using UnityEngine;

namespace WeaponModules.PassiveModules
{
    [CreateAssetMenu(fileName = "JumpModule", menuName = "Passive Modules/Jump module")]
    public class DoubleJumpModule : PassiveModule
    {
        [SerializeField] private int jumpCount;

        public override void ApplyBuff(PlayerController playerController)
        {
            playerController.SetMaxJumpCount(jumpCount);
        }

        public override void RevertBuff(PlayerController player)
        {
            player.ResetMaxJumpCount();
        }
    }
}