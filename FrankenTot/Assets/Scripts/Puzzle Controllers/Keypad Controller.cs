using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    [SerializeField]
    public string password = "811822";
    public string input = "";

    [SerializeField]
    private GameObject secretWall;
    [SerializeField]
    private float moveAmount = 6f;
    [SerializeField]
    private float moveSpeed;
    private bool hasMoved = false;


    public void MoveWall()
    {
        if (hasMoved == false)
        {
            hasMoved = true;
            StartCoroutine(moveSecretWallUp(secretWall, moveAmount));
        }
        else
        {
            return;
        }
       
    }

    private IEnumerator moveSecretWallUp(GameObject secretWall, float moveAmount)
    {
        Vector3 startPosition = secretWall.transform.position; // Initial  position
        Vector3 endPosition = startPosition + new Vector3(0, moveAmount, 0);
        // Target rotation
        float moveProgress = 0f;

        while (moveProgress < 1f)
        {
            moveProgress += Time.deltaTime * (moveSpeed / moveAmount); // Normalize the move speed based on move amount
            secretWall.transform.position = Vector3.Lerp(startPosition,
            endPosition, moveProgress); // Smoothly interpolate movement
            yield return null;
        }
        secretWall.transform.position = endPosition; // Ensure exact final position
    }


}

