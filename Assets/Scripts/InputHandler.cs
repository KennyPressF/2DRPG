using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] GameObject currentCharacter;
    private Camera _mainCamera;

    Vector3 mouseClickPos;
    Vector3 worldPosition;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (!context.started) { return; }

        RaycastHit2D rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        if (!rayHit.collider) { return; }
        
        switch (LayerMask.LayerToName(rayHit.collider.gameObject.layer))
        {
            case "Ground":
                Debug.Log(("Layer clicked: ") + (LayerMask.LayerToName(rayHit.collider.gameObject.layer)));

                mouseClickPos = Mouse.current.position.ReadValue();
                worldPosition = Camera.main.ScreenToWorldPoint(mouseClickPos);

                currentCharacter.GetComponent<CharacterController>().MoveToMouseClickPoint(worldPosition);
                break;


            case "Characters":
                Debug.Log(("Layer clicked: ") + (LayerMask.LayerToName(rayHit.collider.gameObject.layer)));
                break;

            case "":
                break;

            default:
                break;
        }
    }
}
