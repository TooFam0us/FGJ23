using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wapoint : MonoBehaviour
{
    public GameObject Target;
    public int PointsToGive;

    public GameObject GetTarget()
    {
        return Target;
    }

    public int GetPointsToGive()
    {
        return PointsToGive;
    }
}
