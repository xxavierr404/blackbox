using Controllers;
using Objects.Characters;
using UnityEngine;

namespace WeaponModules.PassiveModules
{
    public class MaxHealthModule : PassiveModule
    {
        [SerializeField] private int newHealth;

        private int _oldHealth;
        private Player _player;

        public override void ApplyBuff(PlayerController playerController)
        {
            _player = playerController.GetComponent<Player>();
            _oldHealth = _player.CurrentMaxHealth;
            _player.CurrentMaxHealth = newHealth;
        }

        public override void RevertBuff(PlayerController playerController)
        {
            if (!_player) _player = playerController.GetComponent<Player>();

            _player.CurrentMaxHealth = _oldHealth;
        }
    }
}