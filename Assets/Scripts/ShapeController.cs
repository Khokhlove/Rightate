using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShapeController : MonoBehaviour
{
    public Shape shape;
    public float speedDestroy;
    public Dictionary<Shape.ShapeType, Shape> shapes = new Dictionary<Shape.ShapeType, Shape>();
    public Shape currentShape;

    private void Start()
    {
        shapes.Add(Shape.ShapeType.Cube, shape);
    }

    public void Create()
    {
        int shapeLenght = Enum.GetNames(typeof (Shape.ShapeType)).Length;     
        int shapeId = UnityEngine.Random.Range(0, shapeLenght);
        GameObject inst = Instantiate(shapes[(Shape.ShapeType)shapeId].gameObject);
        currentShape = inst.GetComponent<Shape>();
    }

    public void Remove()
    {
        Destroy(currentShape, speedDestroy);
    }
}
