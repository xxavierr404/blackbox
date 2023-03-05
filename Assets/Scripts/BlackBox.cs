using UnityEngine;
using WeaponModules;

public class BlackBox : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    private ShootModule _firstShootModule;
    private ShootModule _secondShootModule;
    private MovementModule _movementModule;

    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            _firstShootModule.Shoot();
        }

        if (Input.GetAxis("Fire2") > 0)
        {
            _secondShootModule.Shoot();
        }
    }

    public void SetMovementModule(MovementModule movementModule)
    {
        _movementModule.RevertBuff(playerController);
        _movementModule = movementModule;
        _movementModule.ApplyBuff(playerController);
    }
}
