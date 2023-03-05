using System;
using UnityEngine;
using WeaponModules;

public class BlackBox : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private ShootModule testModule;
    
    private ShootModule _firstShootModule;
    private ShootModule _secondShootModule;
    private MovementModule _movementModule;
    private Transform _mainTransform;

    private void Start()
    {
        _mainTransform = Camera.main.transform;
        _firstShootModule = testModule;
    }

    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && _firstShootModule)
        {
            _firstShootModule.Shoot(_mainTransform);
        }

        if (Input.GetAxis("Fire2") > 0 && _secondShootModule)
        {
            _secondShootModule.Shoot(_mainTransform);
        }
    }

    public void SetMovementModule(MovementModule movementModule)
    {
        _movementModule.RevertBuff(playerController);
        _movementModule = movementModule;
        _movementModule.ApplyBuff(playerController);
    }
}
