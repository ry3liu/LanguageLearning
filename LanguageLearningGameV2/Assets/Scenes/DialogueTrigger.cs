using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
	
	public Button nextPhrase;
	
	
	 void Start()
	{
		nextPhrase.GetComponentInChildren<Text>().text = "Next";
		//FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		
	}
}
