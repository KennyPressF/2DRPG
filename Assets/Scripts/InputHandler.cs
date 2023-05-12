using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] GameObject currentCharacter;
    private Camera _mainCamera;

    PartyController partyCtrl;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        partyCtrl = FindAnyObjectByType<PartyController>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) { return; }
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        if (!rayHit.collider) { return; }

        switch (LayerMask.LayerToName(rayHit.collider.gameObject.layer))
        {
            case "Ground":
                Debug.Log(("Layer clicked: ") + (LayerMask.LayerToName(rayHit.collider.gameObject.layer)));

                //currentCharacter.GetComponent<CharacterController>().MoveToMouseClickPoint(rayHit.point);
                partyCtrl.SetSelectedCharacterMovePoint(rayHit.point);

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
