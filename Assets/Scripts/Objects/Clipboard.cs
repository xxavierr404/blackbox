using TMPro;
using UnityEngine;

namespace Objects
{
    public class Clipboard : MonoBehaviour
    {
        [SerializeField] private GameObject clipboard;
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] [Multiline] private string content;

        private bool _isShown;

        private void Update()
        {
            if (_isShown && Input.GetKeyDown(KeyCode.E))
            {
                Deactivate();
            }
        }

        public void Activate()
        {
            textMesh.text = content;
            clipboard.SetActive(true);
            _isShown = true;
        }

        public void Deactivate()
        {
            clipboard.SetActive(false);
            _isShown = false;
        }
    }
}