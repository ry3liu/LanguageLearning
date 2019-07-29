using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	//public Text name;
	//public Text textDisplay;
	public TextMeshProUGUI clearTextDisplay;
	public TextMeshProUGUI buttonText;
	
	
	private Queue<string> sentences= new Queue<string>();
	
	public Dialogue dialogue;
	
	public Button nextPhrase;
	//public TextMeshProUGUI button;
	TextMeshProUGUI button;
	
    // Start is called before the first frame update
    void Start()
    {
		button = nextPhrase.GetComponentInChildren<TextMeshProUGUI>();
		button.text = "Next";
        //sentences = new Queue<string>();
		//sentences.Enqueue("hi");
		foreach(string sentence in dialogue.sentences){
			print(sentence);
			sentences.Enqueue(sentence);
			//NextSentence();
		}
		
		NextSentence();
		
    }

    // Update is called once per frame
  /*  public void StartDialogue(Dialogue dialogue)
    {
		//nextPhrase.GetComponentInChildren<Text>().text = "Next";
        Debug.Log("hi"+ dialogue.name);
		//sentences.Clear();
		
		
		foreach(string sentence in dialogue.sentences){
			print(sentence);
			sentences.Enqueue(sentence);
			//NextSentence();
		}
		
		NextSentence();
    }
	*/
	
	public void NextSentence(){
		
		if(sentences.Count ==0){
			Debug.Log("end");
			
			loadScene();
			//return;
		}
		else{
			
			if(sentences.Count ==1){
			buttonText.text = "I'm ready";
			
		}
		string sentence = sentences.Dequeue();
		//textDisplay.text = sentence;
		clearTextDisplay.text = sentence;
		Debug.Log(sentence);}
		
		
		
	}
	
	public void loadScene(){
		SceneManager.LoadScene("checkWords");
	}
	
}


