using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private GameObject currentChar;

    InputActions playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = new InputActions();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void OnMouseDown()
    {
        Debug.Log("www");
    }
}
