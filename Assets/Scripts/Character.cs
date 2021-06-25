using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string characterName;

    [HideInInspector] public RectTransform root;

    public bool enabled { get { return root.gameObject.activeInHierarchy; } set { root.gameObject.SetActive(value); } }

    DialogueSystem dialogueSys;

    public void Say(string speech)
    {
        if (!enabled)
        {
            enabled = true;
        }

        dialogueSys.Say(speech, characterName);
    }

    public Character (string _name, bool enableOnStart = true)
    {
        CharacterManager cm = CharacterManager.instance;
        // locate the character prefab
        GameObject prefab = Resources.Load("Prefabs/Characters/Character[" + _name + "]") as GameObject;
        GameObject characterInstance = GameObject.Instantiate(prefab, cm.characterPanel);

        root = characterInstance.GetComponent<RectTransform>();
        characterName = _name;

        Image characterRenderer = characterInstance.transform.Find("SpriteLayer").GetComponent<Image>();

        dialogueSys = DialogueSystem.instance;

        enabled = enableOnStart;
    }
}
