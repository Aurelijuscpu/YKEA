using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    private float rotationSpeed = 1;

    public void MoveToPosition(Vector3 targetPosition)
    {
        if (transform != null)
        {
            float halfHeight = transform.GetComponent<MeshFilter>().mesh.bounds.extents.y;
            Vector3 aboveGround = targetPosition;
            aboveGround = new Vector3(aboveGround.x, aboveGround.y + halfHeight, aboveGround.z);
            transform.position = aboveGround;
        } else
        {
            Debug.LogError("No attached transform");
        }
    }

    public void RotateAroundYRight()
    {
        if(transform != null)
            transform.Rotate(new Vector3(0, rotationSpeed, 0));
        else
            Debug.LogError("No attached transform");
    }

    public void RotateAroundYLeft()
    {
        if (transform != null)
            transform.Rotate(new Vector3(0, -rotationSpeed, 0));
        else
            Debug.LogError("No attached transform");
    }
}
