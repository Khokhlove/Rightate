using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof (SHape))]
public class GameLogic : MonoBehaviour
{

    float speed; //Скорость анимации
    enum Direction { left = 1, forward, right, back }; //Направлени

    private Coroutine startMove;

    SHape shape;
    Direction dir;
    Vector3 posXYZ;
    Vector3 rotXYZ;

    private void Start()
    {
        shape = GetComponent<SHape>();
    }
    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.A.ToString())))
            dir = Direction.left;
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.W.ToString())))
            dir = Direction.forward;
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.D.ToString())))
            dir = Direction.right;
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.S.ToString())))
            dir = Direction.back;
    }

    void Update()
    {
        switch (dir)
        {
            case Direction.left:
                posXYZ = new Vector3(-1, shape.GetPos(SHape.PositionTypes.left).y, 0);
                rotXYZ = new Vector3(0, 0, shape.GetRot(SHape.PositionTypes.left).z);
                StartCoroutine(Move(posXYZ, 1));
                StartCoroutine(_Rotate(rotXYZ, 1));
                break;
            case Direction.forward:
                posXYZ = new Vector3(0, shape.GetPos(SHape.PositionTypes.left).y, 1);
                StartCoroutine(Move(posXYZ, 1));
                break;
            case Direction.right:
                posXYZ = new Vector3(1, shape.GetPos(SHape.PositionTypes.left).y, 0);
                StartCoroutine(Move(posXYZ, 1));
                break;
            case Direction.back:
                posXYZ = new Vector3(0, shape.GetPos(SHape.PositionTypes.left).y, -1);
                StartCoroutine(Move(posXYZ, 1));
                break;
            default:
                break;
        }
    }

    IEnumerator Move(Vector3 pos, float duration)
    {
        return _Move(pos, duration);
    }
    IEnumerator _Move(Vector3 pos, float duration)
    {
        Vector3 step = (pos - transform.position) / ((1 / Time.deltaTime) * duration);
        while (Vector3.Distance(transform.position, pos) >= 0.1)
        {
            transform.position += step;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator _Rotate(Vector3 rot, float duration)
    {
        Vector3 step = (rot - transform.rotation.eulerAngles) / ((1 / Time.deltaTime) * duration);
        while (Vector3.Distance(transform.rotation.eulerAngles, rot) >= 0.1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + step);
            yield return new WaitForEndOfFrame();
        }
    }

}
