using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveChoices : MonoBehaviour
{
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        index = GameObject.Find("SpeechSystem-Root").GetComponent<TestDialogue>().index;

        if (index == 7)
        {

        }
    }
}
