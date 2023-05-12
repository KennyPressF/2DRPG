using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    [SerializeField] int selectedCharIndex;
    [SerializeField] GameObject selectedCharacter;
    [SerializeField] GameObject[] characters;

    public void SetSelectedCharacterMovePoint(Vector2 clickPos)
    {
        selectedCharacter.GetComponent<CharacterController>().MoveToMouseClickPoint(clickPos);
    }

    public void CycleNextCharSelect()
    {
        selectedCharIndex++;

        if(selectedCharIndex >= characters.Length)
        {
            selectedCharIndex = 0;
        }

        selectedCharacter = characters[selectedCharIndex];

    }
}
