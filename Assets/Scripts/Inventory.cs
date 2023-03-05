using System.Collections.Generic;
using UnityEngine;
using WeaponModules;

public class Inventory: MonoBehaviour
{
    [SerializeField] private List<ShootModule> availableShootModules;
    [SerializeField] private List<MovementModule> availableMovementModules;
}