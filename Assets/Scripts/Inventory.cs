using System;
using System.Collections.Generic;
using Objects;
using UnityEngine;
using WeaponModules;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ShootModule> availableShootModules;
    [SerializeField] private List<PassiveModule> availablePassiveModules;

    public delegate void OnNewShootModule(ShootModule module);

    public delegate void OnNewPassiveModule(PassiveModule module);

    public OnNewShootModule OnNewShootModuleEvent;
    public OnNewPassiveModule OnNewPassiveModuleEvent;

    public List<ShootModule> AvailableShootModules => availableShootModules;
    public List<PassiveModule> AvailablePassiveModules => availablePassiveModules;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)
            && Physics.Raycast(Camera.main.transform.position, 
                Camera.main.transform.forward, 
                out var hit,
                3f))
        {
            var collectible = hit.collider.GetComponent<ModuleCollectible>();
            if (!collectible) return;
            if (collectible.IsPassive)
            {
                availablePassiveModules.Add(collectible.PassiveModule);
                OnNewPassiveModuleEvent?.Invoke(collectible.PassiveModule);
            }
            else
            {
                availableShootModules.Add(collectible.ShootModule);
                OnNewShootModuleEvent?.Invoke(collectible.ShootModule);
            }
            Destroy(hit.collider.gameObject);
        }
    }

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