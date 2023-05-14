using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;

    PartyController partyCtrl;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        partyCtrl = FindAnyObjectByType<PartyController>();
    }

    public void LeftClick(InputAction.CallbackContext context)
    {
        if(!context.started) { return; }

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        if (!rayHit.collider) { return; }

        switch (LayerMask.LayerToName(rayHit.collider.gameObject.layer))
        {
            case "Ground":
                Debug.Log(("Layer clicked: ") + (LayerMask.LayerToName(rayHit.collider.gameObject.layer)));

                partyCtrl.SetSelectedCharacterMovePoint(rayHit.point);

                break;

            case "Characters":
                Debug.Log(("Layer clicked: ") + (LayerMask.LayerToName(rayHit.collider.gameObject.layer)));
                break;

            case "Obstacle":
                Debug.Log(("Layer clicked: ") + (LayerMask.LayerToName(rayHit.collider.gameObject.layer)));
                break;

            default:
                break;
        }
    }

    public void NextCharacterButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            partyCtrl.CycleNextCharSelect();

        }
    }

    public void PreviousCharacterButton(InputAction.CallbackContext content)
    {
        if(content.started)
        {
            partyCtrl.CyclePrevCharSelect();
        }
    }
}
