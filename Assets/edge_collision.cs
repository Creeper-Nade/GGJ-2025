using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edge_collision : MonoBehaviour
{
    RectTransform rt;
        private void Awake()
    {
        rt=GetComponent<RectTransform>();
        AddCollider();
    }

    public void AddCollider()
    {

        // Get or Add Edge Collider 2D component
        var edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : gameObject.GetComponent<EdgeCollider2D>();
        Vector3[] v3=new Vector3[4];
        rt.GetWorldCorners(v3);
        Vector2[] v2=v3.toVector2Array();


        // Adding edge points
        for(int i=0;i<4;i++)
        edgeCollider.points = v2;
    }
}
public static class MyVector3Extension
{
	public static Vector2[] toVector2Array (this Vector3[] v3)
	{
		return System.Array.ConvertAll<Vector3, Vector2> (v3, getV3fromV2);
	}
		
	public static Vector2 getV3fromV2 (Vector3 v3)
	{
		return new Vector2 (v3.x, v3.y);
	}
}
