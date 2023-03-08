using TMPro;
using UnityEngine;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject HUD;
        [SerializeField] private GameObject inventoryHUD;
        [SerializeField] private Inventory inventory;
        [SerializeField] private TMP_Dropdown passiveModuleDropdown;
        [SerializeField] private TMP_Dropdown firstModuleDropdown;
        [SerializeField] private TMP_Dropdown secondModuleDropdown;

        private bool _inventoryOpened;
        private bool InventoryOpened
        {
            get => _inventoryOpened;
            set
            {
                MenuManager.GetInstance().OnMenuStateChangeEvent?.Invoke(value);
                _inventoryOpened = value;
            }
        }

        private void Awake()
        {
            foreach (var module in inventory.AvailablePassiveModules)
                passiveModuleDropdown.options.Add(new TMP_Dropdown.OptionData(module.ModuleName));

            foreach (var module in inventory.AvailableShootModules)
            {
                firstModuleDropdown.options.Add(new TMP_Dropdown.OptionData(module.ModuleName));
                secondModuleDropdown.options.Add(new TMP_Dropdown.OptionData(module.ModuleName));
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                InventoryOpened = !InventoryOpened;
                HUD.SetActive(!InventoryOpened);
                inventoryHUD.SetActive(InventoryOpened);
                Cursor.visible = InventoryOpened;
                Cursor.lockState = InventoryOpened ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }
}