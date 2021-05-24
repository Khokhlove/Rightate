using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public List<Vector3> shapesStartPos;
    public ShapeController shapeController;
    public PlayerController playerController;
    public Dictionary<PlayerController.Direction, Shape> directionShapes = new Dictionary<PlayerController.Direction, Shape>();
    public Timer timer;

    public UnityEvent correctSelection = new UnityEvent();
    public UnityEvent incorrectSelection = new UnityEvent();

    private void Start()
    {
        playerController.animationFinished.AddListener(OnAnimetionFinished);
        shapeController.Create();
        CreateDirectionShapes();

        correctSelection.AddListener(Counter.GetInstance().Add);
        incorrectSelection.AddListener(Counter.GetInstance().Sub);
    }

    public void OnAnimetionFinished(PlayerController.Direction dir, Shape currentShape)
    {
        if (CompareShapes(dir, currentShape))
        {
            correctSelection.Invoke();
        } else
        {
            incorrectSelection.Invoke();
        }

        shapeController.Remove();
        shapeController.Create();
        CreateDirectionShapes();
    }
    void CreateDirectionShapes()
    {
        if (directionShapes.Count > 0)
        {
            foreach (var e in directionShapes)
            {
                Destroy(e.Value.gameObject);
            }

            directionShapes.Clear();
        }

        foreach (var e in Enum.GetValues(typeof(PlayerController.Direction)))
        {
            int id = UnityEngine.Random.Range(0, shapeController.shapes.Count);
            Shape tempShape = shapeController.shapes[id];
            GameObject inst = Instantiate(tempShape.gameObject, shapesStartPos[(int)e], Quaternion.identity, transform);
            directionShapes.Add((PlayerController.Direction)e, inst.GetComponent<Shape>());
        }

        int correctShapeId = UnityEngine.Random.Range(0, directionShapes.Count);
        Destroy(directionShapes[(PlayerController.Direction)correctShapeId].gameObject);
        directionShapes[(PlayerController.Direction)correctShapeId] = Instantiate(shapeController.currentShape, shapesStartPos[correctShapeId], Quaternion.identity, transform);
    }
    bool CompareShapes(PlayerController.Direction dir, Shape shape)
    {
        return directionShapes[dir].Equals(shape);
    }

    void Pause()
    {
    }

    void Unpause()
    {
    }
}
