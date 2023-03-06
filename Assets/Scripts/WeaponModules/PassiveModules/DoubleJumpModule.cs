using Controllers;
using UnityEngine;

namespace WeaponModules.PassiveModules
{
    [CreateAssetMenu(fileName = "JumpModule", menuName = "Passive Modules/Jump module")]
    public class DoubleJumpModule : PassiveModule
    {
        [SerializeField] private int jumpCount;
        
        public override void ApplyBuff(PlayerController player)
        {
            player.SetMaxJumpCount(jumpCount);
        }

        public override void RevertBuff(PlayerController player)
        {
            player.ResetMaxJumpCount();
        }
    }
}