﻿using UnityEngine;

namespace UI
{
    public class ResourcesUICreator : MonoBehaviour
    {
        [SerializeField] private UIResourceInitializer resourcePrefab;
        [SerializeField] private Canvas canvasPrefab;
        [SerializeField] private ResourceType[] resourceTypes;
        [SerializeField] private Vector2 startPos;
        [SerializeField] private Vector2 offset;

        public void CreateUI(ResourcesStorage resources)
        {
            var currentPos = startPos;
            var canvasInstance = Instantiate(canvasPrefab);

            foreach (var resourceType in resourceTypes)
            {
                var resourceInstance = Instantiate(resourcePrefab);
                resourceInstance.Init(canvasInstance, currentPos, resourceType, resources);
                currentPos += offset;
            }
        }
    }
}
