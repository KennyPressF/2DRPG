using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveToVector2 : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 targetPos;
    bool isMoving = false;

    public void MoveToWaypoint(Vector2 waypointPos)
    {
        targetPos = waypointPos;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving && (Vector2)transform.position != targetPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, (moveSpeed * Time.deltaTime));
        }
        else
        {
            isMoving = false;
        }
    }
}
