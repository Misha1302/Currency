using System;
using UI;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private ResourcesStorage _resources;
    [SerializeField] private ResourcesUICreator _UICreator;

    private void Awake()
    {
        if (_resources == null)
            throw new ArgumentNullException(nameof(ResourcesStorage));

        if (_UICreator == null)
            throw new NullReferenceException(nameof(ResourcesUICreator));

        _resources.InitResources();
        _UICreator.CreateUI(_resources);
    }
}
