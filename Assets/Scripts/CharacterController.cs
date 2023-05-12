using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 targetPos;
    bool isMoving = false;

    private void Update()
    {
        ProcessMovement();
    }

    public void MoveToMouseClickPoint(Vector3 mouseClickPoint)
    {
        mouseClickPoint.z = 0;
        targetPos = (Vector2)mouseClickPoint;
        isMoving = true;
    }

    private void ProcessMovement()
    {
        if (isMoving && (Vector2)transform.position != targetPos)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
        }
        else
        {
            isMoving = false;
        }
    }
}
