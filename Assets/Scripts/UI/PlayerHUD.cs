using System;
using System.Globalization;
using Objects.Characters;
using TMPro;
using UnityEngine;
using WeaponModules;

namespace UI
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private BlackBox blackBox;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI firstModuleCooldownText;
        [SerializeField] private TextMeshProUGUI secondModuleCooldownText;

        private void Awake()
        {
            player.OnChangeHealthEvent += health => healthText.SetText(health.ToString());
        }

        private void Update()
        {
            firstModuleCooldownText.SetText(GetModuleStatus(blackBox.FirstShootModule));
            secondModuleCooldownText.SetText(GetModuleStatus(blackBox.SecondShootModule));
        }

        private String GetModuleStatus(ShootModule module)
        {
            if (!module) return "Не установлен";
            if (module.CanShoot || module.TimeUntilNextShoot <= 0) return "Готов";

            return module.TimeUntilNextShoot.ToString(CultureInfo.InvariantCulture);
        }
    }
}