using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShapeController))]

public class GameController : MonoBehaviour
{
    public List<Vector3> shapesStartPos;
    public ShapeController shapeController;
    public PlayerController playerController;
    public Dictionary<PlayerController.Direction, Shape> directionShapes = new Dictionary<PlayerController.Direction, Shape>();
    public Timer timer;

    private void Start()
    {
        playerController.directionChanged.AddListener(OnDirectionChanged);
        shapeController.Create();
        CreateDirectionShapes();
        
    }

    public void OnDirectionChanged(PlayerController.Direction dir, Shape shape)
    {
        if (CompareShapes(dir, shape))
        {
            Counter.GetInstance().Add();
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
            GameObject inst = Instantiate(tempShape.gameObject, shapesStartPos[(int)e], Quaternion.identity);
            directionShapes.Add((PlayerController.Direction)e, inst.GetComponent<Shape>());
        }

        int correctShapeId = UnityEngine.Random.Range(0, directionShapes.Count);
        Destroy(directionShapes[(PlayerController.Direction)correctShapeId].gameObject);
        directionShapes[(PlayerController.Direction)correctShapeId] = Instantiate(shapeController.currentShape, shapesStartPos[correctShapeId], Quaternion.identity);
    }
    bool CompareShapes(PlayerController.Direction dir, Shape shape)
    {
        return true;
    }
    void Pause()
    {
    }
    void Unpause()
    {
    }
}
