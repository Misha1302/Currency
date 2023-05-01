using TMPro;
using UnityEngine;

namespace UI
{
    public class UIResourceInitializer : MonoBehaviour
    {
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private string stringFormat = "{0}: {1:0.}";
        private ResourceType _resourceType;

        // ReSharper disable once Unity.InefficientPropertyAccess
        public void Init(Canvas canvasInstance, Vector2 currentPos, ResourceType resourceType)
        {
            _resourceType = resourceType;

            transform.SetParent(canvasInstance.transform);
            transform.localPosition = currentPos;

            ChangeText(0);
        }

        private void ChangeText(float amount)
        {
            amountText.text = string.Format(stringFormat, _resourceType, amount);
        }
    }
}