namespace UI
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIResourceInitializer : MonoBehaviour
    {
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private Button increaseButton;
        [SerializeField] private Button decreaseButton;
        [SerializeField] private string stringFormat = "{0}: {1:0.}";
        private ResourceType _resourceType;

        // ReSharper disable once Unity.InefficientPropertyAccess
        public void Init(Canvas canvasInstance, Vector2 currentPos, ResourceType resourceType)
        {
            _resourceType = resourceType;

            transform.SetParent(canvasInstance.transform);
            transform.localPosition = currentPos;

            SubscribeToButtons();

            ChangeText(0);
        }

        private void SubscribeToButtons()
        {
            increaseButton.onClick.AddListener(() =>
                Service<ResourcesStorage>.Instance.IncreaseResource(_resourceType, 1)
            );
            decreaseButton.onClick.AddListener(() =>
                Service<ResourcesStorage>.Instance.DecreaseResource(_resourceType, 1)
            );

            Service<ResourcesStorage>.Instance.ResourceChangedEvent += OnResourceChanged;
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