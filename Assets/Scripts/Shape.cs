using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape: MonoBehaviour
{
    public enum ShapeType {Cube, Sphere, Cylinder, Parallelepiped};
    public ShapeType type;

    public override bool Equals(object shape)
    {
        Shape temp = (Shape)shape;
        return this.type == temp.type;
    }
}
