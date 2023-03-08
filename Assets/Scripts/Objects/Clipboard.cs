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
        private float _secondsBeforeClosing;
        private const float SecondsBeforeClosing = 2;

        private void Update()
        {
            if (_isShown && Input.GetKeyDown(KeyCode.E) && _secondsBeforeClosing <= 0) Deactivate();
            if (_secondsBeforeClosing > 0) _secondsBeforeClosing -= Time.deltaTime;
        }

        public void Activate()
        {
            textMesh.text = content;
            clipboard.SetActive(true);
            _isShown = true;
            _secondsBeforeClosing = SecondsBeforeClosing;
        }

        public void Deactivate()
        {
            clipboard.SetActive(false);
            _isShown = false;
        }
    }
}