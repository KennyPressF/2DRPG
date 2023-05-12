using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveToMouseClickPoint(Vector3 point)
    {
        var targetDestination = new Vector3(point.x, point.y);
        
        while (transform.position != targetDestination)
        {
            transform.Translate(point);
        }
    }
}
