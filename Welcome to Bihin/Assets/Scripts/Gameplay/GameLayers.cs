using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask solidObjectsLayer;

    public static GameLayers I { get; set; }
    private void Awake()
    {
        I = this;
    }

    public LayerMask InteractableLayer
    {
        get => interactableLayer;
    }

    public LayerMask SolidObjectsLayer
    {
        get => solidObjectsLayer;
    }
}
