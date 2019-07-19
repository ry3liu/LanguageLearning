﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text name;
	public Text textDisplay;
	public Text buttonText;
	
	private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("hi"+ dialogue.name);
		sentences.Clear();
		
		foreach(string sentence in dialogue.sentences){
			sentences.Enqueue(sentence);
			//NextSentence();
		}
		
		NextSentence();
    }
	
	public void NextSentence(){
		
		if(sentences.Count ==0){
			Debug.Log("end");
			buttonText.text = "I'm ready";
			return;
		}
		
		string sentence = sentences.Dequeue();
		textDisplay.text = sentence;
		Debug.Log(sentence);
		
	}
	
}