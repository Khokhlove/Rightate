using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHape : MonoBehaviour
{
    public List<Vector3> position;
    public List<Quaternion> rotation;
    public enum PositionTypes {startPos, left, forward, right, back};
    public Vector3 GetPos(PositionTypes posT)
    {
        return position[(int)posT];
    }
    public Quaternion GetRot(PositionTypes posT)
    {
        return rotation[(int)posT];
    }


    /*Transform GetTransform(PositionTypes posT)
    {
        Transform trans = null;
        trans.position = GetPos(posT);
        trans.rotation = GetRot(posT);
        return trans;
    }*/

}
