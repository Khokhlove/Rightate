using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    public float destroySpeed;
    public List<Shape> shapes = new List<Shape>();
    public Shape currentShape;

    public void Create()
    {        
        int shapeId = UnityEngine.Random.Range(0, shapes.Count);
        GameObject inst = Instantiate(shapes[shapeId].gameObject);
        currentShape = inst.GetComponent<Shape>();
    }

    public void Remove()
    {
        if (currentShape != null)
        {
            Destroy(currentShape.gameObject, destroySpeed);
            currentShape = null;
        }
    }
}
