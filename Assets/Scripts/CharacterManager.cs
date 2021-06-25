using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Responsible for adding and maintaining characters in the scene
/// </summary>
public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance = null;

    public RectTransform characterPanel;

    public List<Character> characterList = new List<Character>();

    public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public Character GetCharacter(string characterName, bool createCharacterIfNotExisting = true, bool enableCreatedCharacterOnstart = true)
    {
        int index = -1;
        if (characterDictionary.TryGetValue(characterName, out index))
        {
            return characterList[index];
        }
        else if (createCharacterIfNotExisting)
        {
            return CreateCharacter(characterName, enableCreatedCharacterOnstart);
        }

        return null;
    }

    public Character CreateCharacter(string characterName, bool enableOnStart = true)
    {
        Character newCharacter = new Character(characterName, enableOnStart);

        characterDictionary.Add(characterName, characterList.Count);
        characterList.Add(newCharacter);

        return newCharacter;
    }
}
