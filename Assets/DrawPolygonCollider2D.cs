using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolygonCollider2D))]
public class DrawPolygonCollider2D : MonoBehaviour
{

    PolygonCollider2D PolygonCollider;
    // Use this for initialization
    void Start()
    {
        //PolygonCollider = GetComponent<PolygonCollider2D>();
        //var mesh = new Mesh();
        //var points = new Vector3[PolygonCollider.points.Length];
        //for (int i = 0; i < PolygonCollider.points.Length; i++)
        //{
        //    points[i] = PolygonCollider.points[i];
        //}
        //mesh.vertices = points;
        
    }

    // Update is called once per frame
    void Update()
    {
        //PolygonCollider.points;
    }
}
