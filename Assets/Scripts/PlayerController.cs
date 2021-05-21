using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public enum Direction {Left, Up, Right, Down};
    private Direction direction;
    public ShapeController shapeController;
    public UnityEvent<Direction, Shape> directionChanged;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A)) Left();
        if (Input.GetKeyUp(KeyCode.W)) Up();
        if (Input.GetKeyUp(KeyCode.S)) Right();
        if (Input.GetKeyUp(KeyCode.D)) Down();
    }
    void _Move(Vector3 pos, Vector3 rot)
    {
        directionChanged.Invoke(direction, shapeController.currentShape);
        //shapeController.currentShape.transform.position
    }

    public void Left()
    {
        direction = Direction.Left;
        _Move(Vector3.zero, Vector3.zero);
    }
    public void Up()
    {
        direction = Direction.Up;
        _Move(Vector3.zero, Vector3.zero);
    }
    public void Right()
    {
        direction = Direction.Right;
        _Move(Vector3.zero, Vector3.zero);
    }
    public void Down()
    {
        direction = Direction.Down;
        _Move(Vector3.zero, Vector3.zero);
    }

}
