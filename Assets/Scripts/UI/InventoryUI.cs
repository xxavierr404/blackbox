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
                _inventoryOpened = !_inventoryOpened;
                HUD.SetActive(!_inventoryOpened);
                inventoryHUD.SetActive(_inventoryOpened);
                Cursor.visible = _inventoryOpened;
                Cursor.lockState = _inventoryOpened ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }
}