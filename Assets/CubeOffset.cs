using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOffset : MonoBehaviour
{
    float offset;
    void Start()
    {
        offset = UnityEngine.Random.Range(0, 1); 
    }

}
