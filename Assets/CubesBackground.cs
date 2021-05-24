using System.Collections.Generic;
using UnityEngine;

public class CubesBackground: MonoBehaviour
{
    public GameObject template;
    public List<GameObject> cubes;

    void Start()
    {
        InitCubes();
        transform.position = new Vector3(11, 8, 290);
        transform.rotation = Quaternion.Euler(new Vector3(45, 200, 0));
        transform.localScale = new Vector3(2, 2, 2);
    }

    void InitCubes()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector3 pos = new Vector3(i, 0, j);
                GameObject temp = Instantiate(template, pos, Quaternion.identity, transform);
                cubes.Add(temp);
            }
        }
    }
}
