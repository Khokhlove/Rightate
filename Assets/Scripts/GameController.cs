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

    public GameObject particleWrapper;

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
        ClearDirectionShapes();
        particleWrapper = new GameObject("[ParticleWrapper]");
        foreach (var e in Enum.GetValues(typeof(PlayerController.Direction)))
        {
            int id = UnityEngine.Random.Range(0, shapeController.shapes.Count);
            Shape tempShape = shapeController.shapes[id];
            GameObject inst = Instantiate(tempShape.particle.gameObject, shapesStartPos[(int)e], Quaternion.identity,particleWrapper.transform);
            tempShape.particleInstance = inst;
            directionShapes.Add((PlayerController.Direction)e, tempShape);
        }
        int correctShapeId = UnityEngine.Random.Range(0, directionShapes.Count);
        Destroy(directionShapes[(PlayerController.Direction)correctShapeId].particleInstance);
        Shape correctShape = shapeController.currentShape;
        GameObject correctShapeParticle = Instantiate(correctShape.particle.gameObject, shapesStartPos[correctShapeId], Quaternion.identity, particleWrapper.transform);
        directionShapes[(PlayerController.Direction)correctShapeId] = correctShape;
    }

    private void ClearDirectionShapes()
    {
        if (directionShapes.Count > 0)
        {
            foreach (var e in directionShapes)
            {      
                e.Value.particleInstance = null;
            }
            DestroyImmediate(particleWrapper);
            directionShapes.Clear();
        }
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
