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
        foreach (PlayerController.Direction e in Enum.GetValues(typeof(PlayerController.Direction)))
        {
            int id = UnityEngine.Random.Range(0, shapeController.shapes.Count);
            Shape tempShape = shapeController.shapes[id];
            GameObject inst = Instantiate(tempShape.particle.gameObject, shapesStartPos[(int)e], GetRotationFromDirection(e), particleWrapper.transform);
            tempShape.particleInstance = inst;
            directionShapes.Add(e, tempShape);
        }

        PlayerController.Direction correctDirection = (PlayerController.Direction)UnityEngine.Random.Range(0, directionShapes.Count);
        
        Destroy(directionShapes[correctDirection].particleInstance);
        Shape correctShape = shapeController.currentShape;
        GameObject correctShapeParticle = Instantiate(correctShape.particle.gameObject, shapesStartPos[(int)correctDirection], GetRotationFromDirection(correctDirection), particleWrapper.transform);
        directionShapes[correctDirection] = correctShape;
    }

    Quaternion GetRotationFromDirection(PlayerController.Direction direction)
    {
        Dictionary<PlayerController.Direction, Vector3> rotationVector = new Dictionary<PlayerController.Direction, Vector3>
        {
            { PlayerController.Direction.Left, new Vector3(0, -90, 0) },
            { PlayerController.Direction.Right, new Vector3(0, 90, 0) },
            { PlayerController.Direction.Up, new Vector3(0, 0, 0) },
            { PlayerController.Direction.Down, new Vector3(0, 180, 0) }
        };

        return Quaternion.Euler(rotationVector[direction]);
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
