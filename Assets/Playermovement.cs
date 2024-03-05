using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20.0f;
    private float targetYPosition;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving && transform.position.y < 3.79f)
        {
            targetYPosition = Mathf.Min(transform.position.y + 2, 7.79f);
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            targetYPosition = Mathf.Max(transform.position.y - 2, -4.20f);
            isMoving = true;
        }

        if (isMoving)
        {
            float newYPosition = Mathf.MoveTowards(transform.position.y, targetYPosition, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
            if (Mathf.Approximately(transform.position.y, targetYPosition))
            {
                isMoving = false;
            }
        }
    }
}
