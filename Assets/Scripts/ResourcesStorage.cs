using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesStorage : MonoBehaviour
{
    private readonly Dictionary<ResourceType, float> _resources = new();

    private void Start()
    {
        if (Service<ResourcesStorage>.Instance != null)
            throw new InvalidOperationException("This class was created earlier");

        Service<ResourcesStorage>.Instance = this;
    }

    public void IncreaseResource(float value, ResourceType type)
    {
        ThrowIfLessThanZero(value);
        _resources[type] += value;
    }

    private static void ThrowIfLessThanZero(float value)
    {
        if (value < 0) throw new InvalidOperationException("Value must be greater than zero");
    }

    public void DecreaseResource(float value, ResourceType type)
    {
        ThrowIfLessThanZero(value);
        _resources[type] -= value;
    }
}