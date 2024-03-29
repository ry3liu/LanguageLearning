﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class threeScene : MonoBehaviour
{
    // Start is called before the first frame update
	List<string> frenchFood, frenchCold, frenchSick;
	
	//the overall collection of all the words grouped together.
	public static string[,] wordThreeInstanceFrench = new string[3,3];
	public static string[,] wordThreeInstanceEnglish = new string[3,3];
	public Button []buttonListThreeScene = new Button[3];
	private Dictionary<int, string> numToPic= new Dictionary<int, string>();
	private Dictionary<int, string> numToWord= new Dictionary<int, string>();
	private Dictionary<int, List<string>> numToList= new Dictionary<int, List<string>>();
	
	
	private Dictionary<int, string> instruction= new Dictionary<int, string>();
	
	private Dictionary<string, string> wordList= new Dictionary<string, string> ();
	public storeWord instanceOfStoreWord;
	public List<string> testExample = new List<string>();
	public TextMeshProUGUI instructionText;
	
	//public Audio [] soundForestScene = new Audio[4];
	List<Audio> soundForestScene = new List<Audio>();
	
	Sprite pic;
	
	RectTransform trans;
	
	GameObject[] listingItem;
	public GameObject person;
	
	//in 2D array, food =0, cold=1, sick=2
	
	int ifrenchFood=0;
	int	ifrenchCold =0;
	int ifrenchSick=0;
	int trackNumInOverall = 0;
	
	int trackRow = 0;
	int trackColumn = 0;
	
	
	
    void Start()
    {
		
		FindObjectOfType<audioManager>().setSound("sympathy",soundForestScene);
		FindObjectOfType<audioManager>().setSound("cheering",soundForestScene);
		
		listingItem = GameObject.FindGameObjectsWithTag("itemInForest");
		/*
		wordList.Add("les coquilles Saint-Jacques", "scallops");
		wordList.Add("le poivron", "bellpepper");
		wordList.Add("le chou-fleur", "cauliflower");
		wordList.Add("l'aubergine", "eggplant");
		
		wordList.Add("la moufle", "mitten");
		wordList.Add("le sparadrap", "surgicaltape");
		
		
		wordList.Add("le casque", "helmet");
		wordList.Add("la pilule", "pill");
		*/
		
		//storeWord.printhi();
        frenchFood = new List<string>{"les coquilles Saint-Jacques", "le poivron","le chou-fleur","l'aubergine"};
		frenchCold = new List<string>{"le casque", "la moufle"};
		frenchSick = new List<string>{"le sparadrap", "la pilule"};
		testExample.Add("les coquilles Saint-Jacques");
		testExample.Add("le casque");
		testExample.Add("le sparadrap");
		
		
		
		testExample.Add("le poivron");
		testExample.Add("la moufle");
		testExample.Add("la pilule");
		
		
		numToPic.Add(0,"man_hungry_need_add_food");
		numToPic.Add(1,"man_cold");
		numToPic.Add(2,"man_vomiting");
		
		numToWord.Add(0,"a faim");
		numToWord.Add(1,"a friod");
		numToWord.Add(2,"est blesse");
		
		numToList.Add(0,frenchFood);
		numToList.Add(1,frenchCold);
		numToList.Add(2,frenchSick);
		
		instruction.Add(0,"Le homme a faim, donne-lui...");
		instruction.Add(1,"Le homme a friod, donne-lui...");
		instruction.Add(2,"Le homme est blesse, donne-lui...");
		//print(wordList["le poivron"]);
		//print(wordList["le chou-fleur"]);
		
		//print(frenchFood.Contains("le sparadrap"));
		
		
		
		foreach(string frenchString in updatePic.listWords ){
		//foreach(string frenchString in testExample ){
			if(frenchFood.Contains(frenchString)){
				wordThreeInstanceFrench[0,ifrenchFood] = frenchString;
				//wordThreeInstanceEnglish[0,ifrenchFood] = storeWord.english_words[trackNumInOverall];
				wordThreeInstanceEnglish[0,ifrenchFood] =storeWord.wordList[frenchString];
				print(storeWord.wordList[frenchString]);
				ifrenchFood = ifrenchFood+1;
			}
			else if(frenchCold.Contains(frenchString)){
				wordThreeInstanceFrench[1,ifrenchCold] = frenchString;
				//wordThreeInstanceEnglish[1,ifrenchCold] = storeWord.english_words[trackNumInOverall];
				wordThreeInstanceEnglish[1,ifrenchCold] =storeWord.wordList[frenchString];
				ifrenchCold = ifrenchCold+1;
				print(storeWord.wordList[frenchString]);
			}
			else if(frenchSick.Contains(frenchString)){
				wordThreeInstanceFrench[2,ifrenchSick] = frenchString;
				wordThreeInstanceEnglish[2,ifrenchSick] =storeWord.wordList[frenchString];
				//wordThreeInstanceEnglish[2,ifrenchSick] = storeWord.english_words[trackNumInOverall];
				ifrenchSick = ifrenchSick+1;
				print(storeWord.wordList[frenchString]);
			}
			
			
			trackNumInOverall = trackNumInOverall+1;
			
		}
		
		callHouse();
    }

	
	public void setFunction(){
		foreach(Button oneButton in buttonListThreeScene){
			oneButton.onClick.AddListener(delegate {buttonClickThreeScene(oneButton.GetComponentInChildren<Text>().text);});
			//oneButton.GetComponentInChildren<Text>().text = nameButton[indices];
			
			
		}
	}
	
	public void setItemPic( GameObject picToSet, string englishName){
		
			
		picToSet.name = englishName;
		trans = picToSet.GetComponent<RectTransform>();
		trans.sizeDelta=new Vector2(150,150);
		
		//manage the upper and lower case.
		//works
		//pic = Resources.Load<Sprite>(wordList[french[found[0]]]);
		pic = Resources.Load<Sprite>(englishName);
		picToSet.GetComponent<Image>().sprite = pic;
		
		
		
		
	}
	
	
	public void buttonClickThreeScene(string buttonStr){
		print("french"+buttonStr);
		print("english"+storeWord.wordList[buttonStr]);
		GameObject imageButton = GameObject.Find(storeWord.wordList[buttonStr]);
		print(imageButton.name);
		
		StartCoroutine(moveItem(imageButton, buttonStr));
		
	}
	
	public void houseKeeperFunction(int typeScene, int withinScene){
		List<int> arrayNum = new List<int> {0,1,2};
		instanceOfStoreWord.sayHi(numToPic[typeScene],false);
		print("scene to load: "+typeScene);
		instructionText.text = instruction[typeScene];
		buttonListThreeScene[typeScene].GetComponentInChildren<Text>().text= wordThreeInstanceFrench[typeScene, withinScene];
		print("change button name");
		print("item1" + wordThreeInstanceEnglish[0, 0]);
		print("item1" + wordThreeInstanceEnglish[typeScene, withinScene]);
		setItemPic(listingItem[typeScene],wordThreeInstanceEnglish[typeScene, withinScene]);
		//shouldn't be numToList, it should be word list that users have chosen.
		arrayNum.Remove(typeScene);
		foreach(int individual in arrayNum){
			int number = Random.Range(0,2);
			//int number = 0;
			buttonListThreeScene[individual].GetComponentInChildren<Text>().text= wordThreeInstanceFrench[individual, number];
			setItemPic(listingItem[individual],wordThreeInstanceEnglish[individual, number]);
			print("item2" + wordThreeInstanceEnglish[individual, number]);
			print("item1" + wordThreeInstanceEnglish[individual, 1]);
		}
		//setItemPic(trackColumn,wordThreeInstanceEnglish);
		
		setFunction();
		//load words
	}
	
	IEnumerator moveItem( GameObject thisItem, string buttonSTR){
		Vector2 Original = thisItem.transform.position;
		yield return new WaitForSeconds(1f);
		thisItem.transform.position = Vector2.Lerp(Original, person.transform.position, 1);
		print(numToList[trackRow][0]);
		//string frenchW = wordList.FirstOrDefault(x => x.Value == thisItem.name).Key;
		print(buttonSTR);
		yield return new WaitForSeconds(0.8f);
		if(numToList[trackRow].Contains(buttonSTR)){
			print("### entered the right item");
			FindObjectOfType<audioManager>().playSound("cheering",soundForestScene);
			
			yield return new WaitForSeconds(1.5f);
			thisItem.transform.position = Vector2.Lerp(person.transform.position, Original, 1);
			updateRowColumn();
			callHouse();
		}
		else{
			FindObjectOfType<audioManager>().playSound("sympathy",soundForestScene);
			yield return new WaitForSeconds(1.5f);
			thisItem.transform.position = Vector2.Lerp(person.transform.position, Original, 1);
		}
		
	}
	
	private void callHouse(){
		houseKeeperFunction(trackRow,trackColumn);
		print(trackRow+" ,"+trackColumn);
		
		
	}
	
	private void updateRowColumn(){
		
		if(trackColumn <1)
		{
		trackColumn+=1;}
			
		else if(trackRow <1){
			trackColumn=0;
			trackRow+=1;
		}
		else{
			SceneManager.LoadScene("endScene");
		}
	}
	
    // Update is called once per frame
    
}
