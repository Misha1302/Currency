using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIResourceInitializer : MonoBehaviour
    {
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private Button increaseButton;
        [SerializeField] private Button decreaseButton;
        [SerializeField] private string stringFormat = "{0}: {1:0.}";
        private ResourceType _resourceType;

        private ResourcesStorage _resources = null;

        public void Init(Canvas canvasInstance, Vector2 currentPos, ResourceType resourceType, ResourcesStorage resources)
        {
            _resources = resources;
            _resourceType = resourceType;

            transform.SetParent(canvasInstance.transform);
            transform.localPosition = currentPos;

            SubscribeToButtons();

            ChangeText(0);
        }

        private void SubscribeToButtons()
        {
            increaseButton.onClick.AddListener(() => _resources.IncreaseResource(_resourceType, 1));
            decreaseButton.onClick.AddListener(() => _resources.DecreaseResource(_resourceType, 1));

            _resources.ResourceChangedEvent += OnResourceChanged;
        }

        private void OnResourceChanged(ResourceType type, float value)
        {
            if (type == _resourceType)
                ChangeText(value);
        }

        private void ChangeText(float amount)
        {
            amountText.text = string.Format(stringFormat, _resourceType, amount);
        }
    }
}
