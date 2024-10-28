using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{

    public GameObject gameObject;

    [SerializeField]
    public bool isRotating;

    [SerializeField] 
    private float rotationSpeed;

    [SerializeField]
    private float angleX;
    [SerializeField]
    private float angleY;
    [SerializeField]
    private float angleZ;

    public void RotateObject()
    {
        if (!isRotating) // Prevent triggering multiple rotations simultaneously
        {
            StartCoroutine(RotateObjectCoroutine(gameObject, angleX, angleY, angleZ));
        }
    }

    public void RotateBack()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateObjectCoroutine(gameObject, -angleX, -angleY, -angleZ));
        }
    }

    private IEnumerator RotateObjectCoroutine(GameObject objectToRotate, float angleX, float angleY, float angleZ)
    {
        isRotating = true;
        Quaternion startRotation = objectToRotate.transform.rotation; // Initial  rotation
        Quaternion endRotation = startRotation * Quaternion.Euler(angleX, angleY, angleZ);
        // Target rotation
        float rotationProgress = 0f;
        float angle = 0;

        while (rotationProgress < 1f)
        {
            if (angleX != 0)
            {
                angle = angleX;
            }
            else if (angleY != 0)
            {
                angle = angleY;
            }
            else
            {
                angle = angleZ;
            }
            rotationProgress += Time.deltaTime * (rotationSpeed / Mathf.Abs(angle)); // Normalize the rotation speed based on angle
            objectToRotate.transform.rotation = Quaternion.Lerp(startRotation,
            endRotation, rotationProgress); // Smoothly interpolate rotation
            yield return null;
        }
        objectToRotate.transform.rotation = endRotation; // Ensure exact final rotation
        isRotating = false;

    }
}
