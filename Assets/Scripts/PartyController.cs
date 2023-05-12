using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    [SerializeField] GameObject selectedCharacter;
    [SerializeField] GameObject[] characters;

    public void SetSelectedCharacterMovePoint(Vector2 clickPos)
    {
        Debug.Log("ibdc");
        selectedCharacter.GetComponent<CharacterController>().MoveToMouseClickPoint(clickPos);
    }
}
