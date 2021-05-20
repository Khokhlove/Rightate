using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Shape> shapes;
    public PlayerController playerController;
    public Dictionary<PlayerController.Direction, Shape> directionShapes = new Dictionary<PlayerController.Direction, Shape>();
    public Timer timer;

    private void Start()
    {
        CreateDirectionShapes();
        playerController.shapeController.Create();
    }

    public void OnDirectionChanged(PlayerController.Direction dir, Shape shape)
    {
        if (CompareShapes(dir, shape))
        {
            Counter.GetInstance().Add();
        }

        playerController.shapeController.Remove();
        playerController.shapeController.Create();
        CreateDirectionShapes();
    }
    void CreateDirectionShapes()
    {
        if (directionShapes.Count > 0)
        {
            foreach (var e in directionShapes)
            {
                Destroy(e.Value);
            }

            directionShapes.Clear();
        }

        directionShapes.Add(PlayerController.Direction.Left, shapes[0]);
        directionShapes.Add(PlayerController.Direction.Right, shapes[0]);
        directionShapes.Add(PlayerController.Direction.Up, shapes[0]);
        directionShapes.Add(PlayerController.Direction.Down, shapes[0]);
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
