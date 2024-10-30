using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverScript : MonoBehaviour
{

    public GameObject movedObject;

    [SerializeField]
    public bool isMoving;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float X;
    [SerializeField]
    private float Y;
    [SerializeField]
    private float Z;

    public void MoveObject()
    {
        if (!isMoving) // Prevent triggering multiple rotations simultaneously
        {
            StartCoroutine(MoveObjectCoroutine(movedObject, X, Y, Z));
        }
    }

    public void MoveBack()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveObjectCoroutine(movedObject, -X, -Y, -Z));
        }
    }

    private IEnumerator MoveObjectCoroutine(GameObject objectToMove, float X, float Y, float Z)
    {
        isMoving = true;
        Vector3 startPosition = objectToMove.transform.position; // Initial  position
        Vector3 endPosition = startPosition + new Vector3(X, Y, Z);
        // Target rotation
        float moveProgress = 0f;
        float position = 0;

        while (moveProgress < 1f)
        {
            if (X != 0)
            {
                position = X;
            }
            else if (Y != 0)
            {
                position = Y;
            }
            else
            {
                position = Z;
            }
            moveProgress += Time.deltaTime * (moveSpeed / Mathf.Abs(position)); // Normalize the rotation speed based on angle
            objectToMove.transform.position = Vector3.Lerp(startPosition,
            endPosition, moveProgress); // Smoothly interpolate rotation
            yield return null;
        }
        objectToMove.transform.position = endPosition; // Ensure exact final rotation
        isMoving = false;

    }
}
