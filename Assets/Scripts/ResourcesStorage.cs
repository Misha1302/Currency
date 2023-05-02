using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesStorage : MonoBehaviour
{
    private readonly Dictionary<ResourceType, float> _resources = new();
    public Action<ResourceType, float> ResourceChangedEvent;

    public void InitResources()
    {
        var resourceTypes = (ResourceType[])Enum.GetValues(typeof(ResourceType));
        foreach (var type in resourceTypes)
            _resources.Add(type, 0);
    }

    public void IncreaseResource(ResourceType type, float value)
    {
        ThrowIfLessThanZero(value);
        _resources[type] += value;
        ResourceChangedEvent?.Invoke(type, _resources[type]);
    }

    public void DecreaseResource(ResourceType type, float value)
    {
        ThrowIfLessThanZero(value);
        _resources[type] -= value;
        ResourceChangedEvent?.Invoke(type, _resources[type]);
    }


    private static void ThrowIfLessThanZero(float value)
    {
        if (value < 0)
            throw new InvalidOperationException("Value must be greater than zero");
    }

    public float GetAmountOfResource(ResourceType resourceType) => _resources[resourceType];
}
