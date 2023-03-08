using System.Collections.Generic;
using UnityEngine;
using WeaponModules;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ShootModule> availableShootModules;
    [SerializeField] private List<PassiveModule> availablePassiveModules;

    public List<ShootModule> AvailableShootModules => availableShootModules;
    public List<PassiveModule> AvailablePassiveModules => availablePassiveModules;

    public ShootModule GetShootModuleByName(string moduleName)
    {
        foreach (var module in AvailableShootModules)
            if (module.ModuleName.Equals(moduleName))
                return module;

        return null;
    }

    public PassiveModule GetPassiveModuleByName(string moduleName)
    {
        foreach (var module in AvailablePassiveModules)
            if (module.ModuleName.Equals(moduleName))
                return module;

        return null;
    }
}