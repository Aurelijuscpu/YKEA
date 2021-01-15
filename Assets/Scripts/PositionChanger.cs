using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    public void MoveToPosition(Vector3 targetPosition)
    {
        float halfHeight = transform.GetComponent<MeshFilter>().mesh.bounds.extents.y;
        Vector3 aboveGround = targetPosition;
        aboveGround = new Vector3(aboveGround.x, aboveGround.y + halfHeight, aboveGround.z);
        transform.position = aboveGround;
    }

    public void RotateAroundYRight()
    {
        transform.Rotate(new Vector3(0, 1, 0));
    }

    public void RotateAroundYLeft()
    {
        transform.Rotate(new Vector3(0, -1, 0));
    }
}
