using System;
using System.Collections;
using System.Collections.Generic;
using Objects.Characters;
using UnityEngine;

namespace WeaponModules.ShootModules
{
    public class AbyssModule : ShootModule
    {
        [SerializeField] private float attackRadius;
        [SerializeField] private float blackoutDuration;
        [SerializeField] private Light boxLight;

        private Light[] _lights;

        private void Awake()
        {
            _lights = FindObjectsOfType<Light>();
        }

        public override void Shoot(Transform shooter)
        {
            base.Shoot(shooter);
            if (!CanShoot) return;
            
            DisableLights();
            
            var colliders = Physics.OverlapSphere(transform.position, attackRadius);
            foreach (var col in colliders)
            {
                var enemy = col.gameObject.GetComponent<Enemy>();
                if (!enemy) continue;
                enemy.DealDamage(99999999);
            }
        }

        private void DisableLights()
        {
            foreach (var lightOnScene in _lights)
            {
                if (!lightOnScene || lightOnScene == boxLight) continue;
                StartCoroutine(DisableLightTemporarily(lightOnScene));
            }
        }

        private IEnumerator DisableLightTemporarily(Light disabledLight)
        {
            var oldIntensity = disabledLight.intensity;
            disabledLight.intensity = 0;
            yield return new WaitForSeconds(blackoutDuration);
            disabledLight.intensity = oldIntensity;
        }
    }
}