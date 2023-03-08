using System;
using Controllers;
using UnityEngine;
using UnityEngine.Serialization;
using WeaponModules;

public class BlackBox : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private ShootModule firstShootModule;
    [SerializeField] private ShootModule secondShootModule;

    private PassiveModule _passiveModule;
    private Transform _mainTransform;

    public ShootModule FirstShootModule => firstShootModule;
    public ShootModule SecondShootModule => secondShootModule;

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
