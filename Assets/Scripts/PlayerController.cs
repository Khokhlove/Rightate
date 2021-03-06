using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public enum Direction {Left, Up, Right, Down};
    public GameController gameController;
    public ShapeController shapeController;
    public UnityEvent<Direction, Shape> directionChanged;
    public UnityEvent<Direction, Shape> animationFinished;
    public AnimationCurve moveCurve;
    [Range(0.1f ,100)]
    public float speed;

    Direction direction;
    Coroutine _rotation;
    bool isActive = true;

    void Start()
    {
        animationFinished.AddListener((d, s) => { isActive = true; });
    }
    void Update()
    {
            if (Input.GetKeyUp(KeyCode.A)) Left();
            if (Input.GetKeyUp(KeyCode.W)) Up();
            if (Input.GetKeyUp(KeyCode.D)) Right();
            if (Input.GetKeyUp(KeyCode.S)) Down();
    }
   
    void _Move(Vector3 pos, Vector3 rot)
    {
        isActive = false;
        directionChanged.Invoke(direction, shapeController.currentShape);
        _rotation = StartCoroutine(Rotation(rot, shapeController.currentShape.gameObject));
        StartCoroutine(Movement(pos, shapeController.currentShape.gameObject));
    }

    IEnumerator Rotation(Vector3 rot, GameObject shapeObject)
    {
        float time = 0;
        while (Vector3.Distance(shapeObject.transform.rotation.eulerAngles, rot) >= 0.1)
        {
            float value = moveCurve.Evaluate(time * speed);
            shapeObject.transform.rotation = Quaternion.Euler(rot * value);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Movement(Vector3 pos, GameObject shapeObject)
    {
        float time = 0;
        while (Vector3.Distance(shapeObject.transform.position, pos) >= 0.1)
        {
            float value = moveCurve.Evaluate(time * speed);

            shapeObject.transform.position = new Vector3(pos.x * value, pos.y, pos.z * value);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(_rotation);
        animationFinished.Invoke(direction, shapeController.currentShape);
    }
    public void Left()
    {
        if (isActive)
        {
            direction = Direction.Left;
            Vector3 dir = gameController.shapesStartPos[(int)Direction.Left];
            dir.y = shapeController.currentShape.transform.position.y;
            _Move(dir, new Vector3(0, 0, 90));
        }
    }
    public void Up()
    {
        if (isActive)
        {
            direction = Direction.Up;
            Vector3 dir = gameController.shapesStartPos[(int)Direction.Up];
            dir.y = shapeController.currentShape.transform.position.y;
            _Move(dir, new Vector3(90, 0, 0));
        }
    }
    public void Right()
    {
        if (isActive)
        {
            direction = Direction.Right;
            Vector3 dir = gameController.shapesStartPos[(int)Direction.Right];
            dir.y = shapeController.currentShape.transform.position.y;
            _Move(dir, new Vector3(0, 0, -90));
        }
    }
    public void Down()
    {
        if (isActive)
        {
            direction = Direction.Down;
            Vector3 dir = gameController.shapesStartPos[(int)Direction.Down];
            dir.y = shapeController.currentShape.transform.position.y;
            _Move(dir, new Vector3(-90, 0, 0));
        }
    }
}
