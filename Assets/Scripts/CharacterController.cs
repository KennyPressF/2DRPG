using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 lastClickPos;
    bool isMoving = false;

    public void MoveToMouseClickPoint(Vector3 point)
    {
        lastClickPos = new Vector2(point.x, point.y);
        
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving && (Vector2)transform.position != lastClickPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, lastClickPos, (moveSpeed * Time.deltaTime));
        }
        else
        {
            isMoving = false;
        }
    }
}
