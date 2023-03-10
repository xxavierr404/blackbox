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
        [SerializeField] private TextMeshProUGUI firstModuleLabelText;
        [SerializeField] private TextMeshProUGUI secondModuleCooldownText;
        [SerializeField] private TextMeshProUGUI secondModuleLabelText;
        [SerializeField] private GameObject gameOverScreen;

        private void Awake()
        {
            player.OnChangeHealthEvent += health => healthText.SetText(health.ToString());
            player.onDeath.AddListener(() =>
            {
                gameOverScreen.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            });

            blackBox.OnFirstModuleChangeEvent += () =>
            {
                firstModuleLabelText.SetText(blackBox.FirstShootModule
                    ? blackBox.FirstShootModule.ModuleName
                    : "Модуль 1:");
            };

            blackBox.OnSecondModuleChangeEvent += () =>
            {
                secondModuleLabelText.SetText(blackBox.SecondShootModule
                    ? blackBox.SecondShootModule.ModuleName
                    : "Модуль 2:");
            };
        }

        private void Update()
        {
            firstModuleCooldownText.SetText(GetModuleStatus(blackBox.FirstShootModule));
            secondModuleCooldownText.SetText(GetModuleStatus(blackBox.SecondShootModule));
        }

        private string GetModuleStatus(ShootModule module)
        {
            if (!module) return "Не установлен";
            if (module.CanShoot || module.TimeUntilNextShoot <= 0) return "Готов";

            return module.TimeUntilNextShoot.ToString(CultureInfo.InvariantCulture);
        }
    }
}