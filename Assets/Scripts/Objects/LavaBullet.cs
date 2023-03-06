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

            Destroy(this);
        }
    }
}