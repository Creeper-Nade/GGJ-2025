using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edge_collision : MonoBehaviour
{
    Renderer render;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        AddCollider();
    }

    public void AddCollider()
    {

        // Get or Add Edge Collider 2D component
        var edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : gameObject.GetComponent<EdgeCollider2D>();
        Vector3[] v3 = GetSpriteCorners(render);
        Vector2[] v2 = v3.toVector2Array();


        // Adding edge points
        edgeCollider.points = v2;
    }
    public Vector3[] GetSpriteCorners(Renderer renderer)
    {
        Vector3 topRight = new Vector3(0, 0, 0) + new Vector3(1, 1, 0) / 2;
        Vector3 topLeft = new Vector3(0, 0, 0) + new Vector3(-1, 1, 0) / 2;
        Vector3 botLeft = new Vector3(0, 0, 0) + new Vector3(-1, -1, 0) / 2;
        Vector3 botRight = new Vector3(0, 0, 0) + new Vector3(1, -1, 0) / 2;
        return new Vector3[] { topRight, topLeft, botLeft, botRight };
    }
}
public static class MyVector3Extension
{
    public static Vector2[] toVector2Array(this Vector3[] v3)
    {
        return System.Array.ConvertAll<Vector3, Vector2>(v3, getV3fromV2);
    }

    public static Vector2 getV3fromV2(Vector3 v3)
    {
        return new Vector2(v3.x, v3.y);
    }
}
