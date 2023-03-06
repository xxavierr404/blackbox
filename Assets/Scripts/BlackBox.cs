using System;
using Controllers;
using UnityEngine;
using WeaponModules;

public class BlackBox : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private ShootModule testModule;
    [SerializeField] private PassiveModule testPassiveModule;
    
    private ShootModule _firstShootModule;
    private ShootModule _secondShootModule;
    private PassiveModule _passiveModule;
    private Transform _mainTransform;

    private void Start()
    {
        _mainTransform = Camera.main.transform;
        _firstShootModule = testModule;
        SetPassiveModule(testPassiveModule);
    }

    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && _firstShootModule)
        {
            _firstShootModule.Shoot(_mainTransform);
        } else if (_firstShootModule)
        {
            _firstShootModule.StopShooting();
        }

        if (Input.GetAxis("Fire2") > 0 && _secondShootModule)
        {
            _secondShootModule.Shoot(_mainTransform);
        } else if (_secondShootModule)
        {
            _secondShootModule.StopShooting();
        }
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
}
