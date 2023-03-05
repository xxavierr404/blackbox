using UnityEngine;

namespace WeaponModules.MovementModules
{
    [CreateAssetMenu(fileName = "JumpModule", menuName = "Movement Modules/Jump module", order = 0)]
    public class DoubleJumpModule : MovementModule
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