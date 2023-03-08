using Objects;
using UnityEngine;

namespace Controllers
{
    public class ClipboardReader : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)
                && Physics.Raycast(Camera.main.transform.position,
                    Camera.main.transform.forward, out var hit, 5f))
            {
                var clipboard = hit.collider.GetComponent<Clipboard>();
                if (clipboard) clipboard.Activate();
            }
        }
    }
}