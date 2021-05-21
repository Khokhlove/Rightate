using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public enum Direction {Left, Up, Right, Down};
    Direction direction;
    public ShapeController shapeController;
    public UnityEvent<Direction, Shape> directionChanged;
    public UnityEvent<Direction, Shape> animationFinished;
    [Range(1,3)]
    public float speed;
    Coroutine _rotation;
    bool isActive = true;

    void Start()
    {
        animationFinished.AddListener((d, s) => { isActive = true; });
    }
    void Update()
    {
            if (Input.GetKeyUp(KeyCode.A) && isActive) Left();
            if (Input.GetKeyUp(KeyCode.W) && isActive) Up();
            if (Input.GetKeyUp(KeyCode.D) && isActive) Right();
            if (Input.GetKeyUp(KeyCode.S) && isActive) Down();
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
        Vector3 step = (rot - shapeObject.transform.rotation.eulerAngles) / (1 / (Time.deltaTime * speed));
        while (Vector3.Distance(shapeObject.transform.rotation.eulerAngles, rot) >= 0.1)
        {
            shapeObject.transform.rotation = Quaternion.Euler(shapeObject.transform.rotation.eulerAngles + step);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Movement(Vector3 pos, GameObject shapeObject)
    {
        Vector3 step = (pos - shapeObject.transform.position) / (1 / (Time.deltaTime * speed));
        while (Vector3.Distance(shapeObject.transform.position, pos) >= 0.1)
        {
            shapeObject.transform.position += step;
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(_rotation);
        animationFinished.Invoke(direction, shapeController.currentShape);
    }
    public void Left()
    {
        direction = Direction.Left;
        _Move(new Vector3(-1, 0, 0), new Vector3(0,0,90));
    }
    public void Up()
    {
        direction = Direction.Up;
        _Move(new Vector3(0, 0, 1), new Vector3(90, 0, 0));
    }
    public void Right()
    {
        direction = Direction.Right;
        _Move(new Vector3(1, 0, 0), new Vector3(0, 0, -90));
    }
    public void Down()
    {
        direction = Direction.Down;
        _Move(new Vector3(0, 0, -1), new Vector3(-90, 0, 0));
    }

}
