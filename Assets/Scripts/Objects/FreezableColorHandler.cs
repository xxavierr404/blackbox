using UnityEngine;

namespace Objects
{
    public class FreezableColorHandler : MonoBehaviour
    {
        [SerializeField] private new MeshRenderer renderer;

        private Color _initialColor;

        private void Start()
        {
            _initialColor = renderer.material.color;
        }

        public void UpdateColor(float currentFreezeRate, float maxFreezeRate)
        {
            if (currentFreezeRate == 0)
            {
                renderer.material.color = _initialColor;
                return;
            }
            
            var freezeRate = Mathf.Clamp(currentFreezeRate, 0, maxFreezeRate);
            var material = renderer.material;
            var oldColor = material.color;
            material.color = new Color(
                oldColor.r * (maxFreezeRate - freezeRate) / maxFreezeRate,
                oldColor.g * (maxFreezeRate - freezeRate) / maxFreezeRate,
                freezeRate / maxFreezeRate);
        }
    }
}