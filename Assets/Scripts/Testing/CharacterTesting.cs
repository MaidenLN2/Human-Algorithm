using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTesting : MonoBehaviour
{
    public Character Mum;
    public Character Dad;

    // Start is called before the first frame update
    void Start()
    {
        Mum = CharacterManager.instance.GetCharacter("Mum", enableCreatedCharacterOnstart: false);
        //Dad = CharacterManager.instance.GetCharacter("Dad", enableCreatedCharacterOnstart: false);
    }

    public string[] speech;
    int i = 0;

    public Vector2 moveTarget;
    public float moveSpeed;
    public bool smooth;

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

        if (Input.GetKeyDown(KeyCode.M))
        {
            Mum.MoveTo(moveTarget, moveSpeed, smooth);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Mum.StopMoving(true);
        }
        
    }
}
