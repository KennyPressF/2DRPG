using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    [SerializeField] int selectedCharIndex;
    [SerializeField] GameObject selectedCharacter;
    [SerializeField] GameObject[] characters;


    //CURRENTLY MOVES ALL CHARS TO THE SAME SPACE
    public void SetSelectedCharacterMovePoint(Vector2 clickPos)
    {
        selectedCharacter.GetComponent<CharacterPathfinder>().SetNewPath(clickPos);
        SetUnselectedCharactersMovePoints(clickPos);
    }

    private void SetUnselectedCharactersMovePoints(Vector2 targetPos)
    {
        foreach (var character in characters)
        {
            //Make this condition false to prevent companion movement
            if (character.GetComponent<CharacterSheet>().isCurrentChosenChar)
            {
                character.GetComponent<CharacterPathfinder>().SetNewPath(targetPos);
            }
        }
    }

    public void CycleNextCharSelect()
    {
        selectedCharacter.GetComponent<CharacterSheet>().isCurrentChosenChar = false;

        selectedCharIndex++;

        if (selectedCharIndex >= characters.Length)
        {
            selectedCharIndex = 0;
        }

        selectedCharacter = characters[selectedCharIndex];
        selectedCharacter.GetComponent<CharacterSheet>().isCurrentChosenChar = true;
    }

    public void CyclePrevCharSelect()
    {
        selectedCharacter.GetComponent<CharacterSheet>().isCurrentChosenChar = false;

        selectedCharIndex--;

        if (selectedCharIndex < 0)
        {
            selectedCharIndex = characters.Length - 1;
        }

        selectedCharacter = characters[selectedCharIndex];

        selectedCharacter.GetComponent<CharacterSheet>().isCurrentChosenChar = true;
    }
}
