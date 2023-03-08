using Controllers;
using TMPro;
using UnityEngine;
using WeaponModules;

public class BlackBox : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Inventory inventory;
    private Transform _mainTransform;
    
    private PassiveModule _passiveModule;
    private bool Locked { get; set; }

    public delegate void OnModuleChange();

    public OnModuleChange OnFirstModuleChangeEvent;
    public OnModuleChange OnSecondModuleChangeEvent;
    
    public ShootModule FirstShootModule { get; private set; }
    public ShootModule SecondShootModule { get; private set; }

    private void Start()
    {
        _mainTransform = Camera.main.transform;
        MenuManager.GetInstance().OnMenuStateChangeEvent += (newState) => Locked = newState;
    }

    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && FirstShootModule && !Locked)
            FirstShootModule.Shoot(_mainTransform);
        else if (FirstShootModule) FirstShootModule.StopShooting();

        if (Input.GetAxis("Fire2") > 0 && SecondShootModule && !Locked)
            SecondShootModule.Shoot(_mainTransform);
        else if (SecondShootModule) SecondShootModule.StopShooting();
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
        }
        else
        {
            FirstShootModule = inventory.GetShootModuleByName(moduleName);
        }

        OnFirstModuleChangeEvent?.Invoke();
    }

    public void SetSecondShootModule(TMP_Dropdown dropdown)
    {
        var moduleName = dropdown.options[dropdown.value].text;
        if (moduleName.Equals("Пусто"))
        {
            SecondShootModule = null;
        }
        else
        {
            SecondShootModule = inventory.GetShootModuleByName(moduleName);
        }

        OnSecondModuleChangeEvent?.Invoke();
    }

    private void SetPassiveModule(PassiveModule passiveModule)
    {
        if (_passiveModule) _passiveModule.RevertBuff(playerController);
        _passiveModule = passiveModule;
        _passiveModule.ApplyBuff(playerController);
    }

    private void ResetPassiveModule()
    {
        if (_passiveModule) _passiveModule.RevertBuff(playerController);

        _passiveModule = null;
    }
}