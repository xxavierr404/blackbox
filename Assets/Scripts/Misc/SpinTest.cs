using System;
using UnityEngine;

namespace Misc
{
    public class SpinTest : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        
        private void Update()
        {
            rb.AddTorque(Vector3.left);
        }
    }
}