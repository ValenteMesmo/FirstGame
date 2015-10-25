using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TrailRenderer))]
public class TrailRendererSortingLayer : MonoBehaviour
{
    public string SortingLayerName = "Background";
    public int SortingOrder = 0;

    void Start()
    {
        var trail = GetComponent<TrailRenderer>();

        trail.sortingLayerName = SortingLayerName;
        trail.sortingOrder = SortingOrder;
    }
}
