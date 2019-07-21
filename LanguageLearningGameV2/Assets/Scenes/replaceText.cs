﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class replaceText : MonoBehaviour
{
    // Start is called before the first frame update
	
	int i =0;
	public storeWord instanceOfStoreWord;
	string[] printWord = new string[4];
	public Button[] buttonList = new Button [4]; 
	public Audio [] soundRecognizeWord = new Audio[3];
	
    void Start()
    {
		
		FindObjectOfType<audioManager>().setSound("sympathy",soundRecognizeWord);
		string inString = "le chou-fleur";
		storeWord.english_words.Add("cauliflower");
		updatePic.listWords.Add(inString);
		
		storeWord.english_words.Add("scallops");
		updatePic.listWords.Add("les coquilles Saint-Jacques");
		
		print("print index of stirng for sex "+ inString.IndexOf("le "));
        
		
		print(storeWord.english_words[i]);
		print(updatePic.listWords[i]);
		
		overallHouseKeeper();
		
		
		
    }
	public void buttonClick(Button click, string toCheck){
		if(click.GetComponentInChildren<Text>().text ==toCheck ){
			overallHouseKeeper();
		}
		
		else{
			FindObjectOfType<audioManager>().playSound("sympathy",soundRecognizeWord);
		}
	}
	
	public void overallHouseKeeper(){
		instanceOfStoreWord.sayHi(storeWord.english_words[i],false);
		printWord = createWordList(updatePic.listWords[i]);
		
		foreach(string oneWord in printWord){
			print(oneWord);
		}
		setButtonName(printWord);
		
		i=i+1;
	}

    // Update is called once per frame
    public string[] createWordList(string buttonText){
		string[] word = new string[4];
		
		word[0]= buttonText;
		
		
		if(buttonText.IndexOf("le ")>-1){
			Regex regexP = new Regex(Regex.Escape("le "));
			word[1]=regexP.Replace(buttonText, "la ",1);
		}
		else if(buttonText.IndexOf("la ")>-1){
			Regex regexP = new Regex(Regex.Escape("la "));
			word[1]=regexP.Replace(buttonText, "le ",1);
		}
		else if(buttonText.IndexOf("les ")>-1){
			Regex regexP = new Regex(Regex.Escape("les "));
			word[1]=regexP.Replace(buttonText, "l' ",1);
		}
		else{
			Regex regexP = new Regex(Regex.Escape("l' "));
			word[1]=regexP.Replace(buttonText, "la ",1);
		}
		
		if(buttonText.IndexOf("o")>-1){
			Regex regexP = new Regex(Regex.Escape("o"));
			word[2]=regexP.Replace(buttonText, "a",1);
		}
		
		else if(buttonText.IndexOf("i")>-1){
			Regex regexP = new Regex(Regex.Escape("i"));
			word[3]=regexP.Replace(buttonText, "",1);
		}
		
		if(word[1].IndexOf("r")>-1){
			Regex regexP = new Regex(Regex.Escape("r"));
			word[3]=regexP.Replace(word[1], "",1);
		}
		else{
			word[3] = word[1].Substring(0, word[1].Length - 1);
		}
		
		return word;
	
	}
	
	
	
	public void setButtonName(string [] nameButton){
		//hey.GetComponentInChildren<Text>().text = picName;
		int indices = 0;
		foreach(Button oneButton in buttonList){
			oneButton.onClick.AddListener(delegate {buttonClick(oneButton, nameButton[0]);});
			oneButton.GetComponentInChildren<Text>().text = nameButton[indices];
			indices = indices +1;
		}
		
	}
	
	
	
	
	
}
