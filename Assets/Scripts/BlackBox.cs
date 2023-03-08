using System;
using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using WeaponModules;

public class BlackBox : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Inventory inventory;

    private PassiveModule _passiveModule;
    private Transform _mainTransform;

    public ShootModule FirstShootModule { get; private set; }
    public ShootModule SecondShootModule { get; private set; }

    private void Start()
    {
        _mainTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && FirstShootModule)
        {
            FirstShootModule.Shoot(_mainTransform);
        } else if (FirstShootModule)
        {
            FirstShootModule.StopShooting();
        }

        if (Input.GetAxis("Fire2") > 0 && SecondShootModule)
        {
            SecondShootModule.Shoot(_mainTransform);
        } else if (SecondShootModule)
        {
            SecondShootModule.StopShooting();
        }
    }

    public void SetPassiveModule(TMP_Dropdown dropdown)
    {
        var moduleName = dropdown.options[dropdown.value].text;
        if (moduleName.Equals("Пусто"))
        {
            ResetPassiveModule();
            return;
        }
        SetPassiveModule(inventory.GetPassiveModuleByName(moduleName));
    }

    public void SetFirstShootModule(TMP_Dropdown dropdown)
    {
        var moduleName = dropdown.options[dropdown.value].text;
        if (moduleName.Equals("Пусто"))
        {
            FirstShootModule = null;
            return;
        }
        FirstShootModule = inventory.GetShootModuleByName(moduleName);
    }

    public void SetSecondShootModule(TMP_Dropdown dropdown)
    {
        var moduleName = dropdown.options[dropdown.value].text;
        if (moduleName.Equals("Пусто"))
        {
            SecondShootModule = null;
            return;
        }
        SecondShootModule = inventory.GetShootModuleByName(moduleName);
    }
    
    private void SetPassiveModule(PassiveModule passiveModule)
    {
        if (_passiveModule)
        {
            _passiveModule.RevertBuff(playerController);
        }
        _passiveModule = passiveModule;
        _passiveModule.ApplyBuff(playerController);
    }

    private void ResetPassiveModule()
    {
        if (_passiveModule)
        {
            _passiveModule.RevertBuff(playerController);
        }

        _passiveModule = null;
    }
}
