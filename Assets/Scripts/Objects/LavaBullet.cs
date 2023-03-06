using System;
using UnityEngine;

namespace Objects
{
    public class LavaBullet: MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            var freezable = collision.gameObject.GetComponent<Freezable>();
            if (freezable)
            {
                freezable.ResetFreezeRate();
            }

            var water = collision.gameObject.GetComponent<WaterDrop>();
            if (water)
            {
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
        }
    }
}