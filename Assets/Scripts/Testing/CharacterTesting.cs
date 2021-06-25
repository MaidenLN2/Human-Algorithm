using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTesting : MonoBehaviour
{
    public Character Mum;

    // Start is called before the first frame update
    void Start()
    {
        Mum = CharacterManager.instance.GetCharacter("Mum", enableCreatedCharacterOnstart: false);
    }

    public string[] speech;
    int i = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (i < speech.Length)
            {
                Mum.Say(speech[i]);
            }
            else
            {
                DialogueSystem.instance.Close();
            }

            i++;

        }
        
    }
}
