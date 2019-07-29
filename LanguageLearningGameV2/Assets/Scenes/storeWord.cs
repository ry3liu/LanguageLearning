using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class storeWord : MonoBehaviour
{
	public static Dictionary<string, string> wordList = new Dictionary<string, string>();
	public List<string> french_words = new List<string>();
	public static List<string> english_words = new List<string>();
	private Dictionary <string, string> french = new Dictionary<string, string>();
	private List<string> found;
	
	public static string word;
	
	public instantButton generate;
	public static List<GameObject> listButton = new List<GameObject>();
	GameObject input;
	
	private static bool entered = false;
	//public Audio [] sounds = new Audio[2];
	List<Audio> sounds = new List<Audio>();
	
	SpriteRenderer one;
	Sprite pic;
	GameObject each;
	Image imagery;
	RectTransform trans;
	GameObject canvas ;
	GameObject text;
	GameObject ButtonPrefab;
	public static int i;
	
    // Start is called before the first frame update
    void Start()
    {
		wordList.Clear();
		 i =-1;
		canvas = GameObject.Find("Canvas");
		ButtonPrefab = GameObject.Find("Button");
		//ButtonPrefab.SetActive(false);
		//each = GameObject.FindWithTag("Player");
		//each.SetActive(false);
		
		
		print("call storeWord first");
		wordList.Add("les coquilles Saint-Jacques", "scallops");
		wordList.Add("le poivron", "bellpepper");
		wordList.Add("le chou-fleur", "cauliflower");
		wordList.Add("l'aubergine", "eggplant");
		
		wordList.Add("la moufle", "mitten");
		wordList.Add("le sparadrap", "surgicaltape");
		
		
		wordList.Add("le casque", "helmet");
		wordList.Add("la pilule", "pill");
		//or words.Value
		
		foreach(KeyValuePair<string, string> words in wordList){
			print(words.Key);
			french_words.Add(words.Key.ToLower());
			french.Add(words.Key.ToLower(), words.Key);
		}
		
		
    }
	
	public void callWordsSprite(string check){
		
		
		each = GameObject.FindWithTag("Player");
		
		print(each.name); //so it is accessing gameobject
		each.transform.localScale = new Vector3(1,1,1);
		one = each.GetComponent<SpriteRenderer>();
		one.size=new Vector2(1,1);
		
		//print(wordList["Les coquilles Saint-Jacques"]);
		found = french_words.FindAll(w=>w.StartsWith(check.ToLower()));
		foreach(string hi in found){
			print(hi);
			word = hi;
		}
		print(french[found[0]]);
		//manage the upper and lower case.
		//works
		//pic = Resources.Load<Sprite>(wordList[french[found[0]]]);
		pic = Resources.Load<Sprite>("Cauliflower");
		one.sprite = pic;
		
		
		//doesn't work 
		//one.size=new Vector2(1,1);
        
	}
	
	
	public void callWordsImage(string check){
		found = french_words.FindAll(w=>w.StartsWith(check.ToLower()));
		input = GameObject.FindWithTag("input");
		print(input.name);
		float addition = 0f;
		foreach(string hi in found){
			print(hi);
			word = hi;
			
			generate.generatePreFab(hi, input.GetComponent<RectTransform>(), addition, canvas,"input", listButton);
			addition = addition + 30;
			
		}
		
		//now you can access the list
		//SceneManager.LoadScene("medicine");
		
		
		//sayHi(check);
		
		
		//doesn't work 
		//one.size=new Vector2(1,1);
        
	}
	
	public void loadWordScene(){
		SceneManager.LoadScene("medicine");
		
		
		//sayHi(check);
		
	}
	
	public void sayHi( string englishPic, bool play){ // add them in learning language scene.
		print("let's see if it get executed first or not");
		//print(french_words[0]);
		
		each = GameObject.FindWithTag("Player");
		
		print("printing the name of image object");
		print(each.name); //so it is accessing gameobject
		//each.transform.localScale = new Vector3(1,1,1);
		imagery = each.GetComponent<Image>();
		trans = each.GetComponent<RectTransform>();
		trans.sizeDelta=new Vector2(200,200);
		
		//manage the upper and lower case.
		//works
		//pic = Resources.Load<Sprite>(wordList[french[found[0]]]);
		pic = Resources.Load<Sprite>(englishPic);
		imagery.sprite = pic;
		
		print("!!!! check to see if : didn't call pronounce workd");
		if(play){
		print("didn't call pronounce workd");
		FindObjectOfType<audioManager>().setSound(englishPic,sounds);
		//playS(englishPic);
		FindObjectOfType<audioManager>().playSound(englishPic,sounds);
		
		}
		
	}
	
	public void setFrenchText(string frenchWord){
		text = GameObject.Find("Text (TMP)");
		text.GetComponent<TMP_Text>().text = frenchWord;
	}
	
	public void gotWord(){
		//ButtonPrefab.SetActive(true);
		//each.SetActive(true);
		//get the french and english word and pass it to sayHi.
		//this is an onclick method
		//find a way to go to next thing in list.
		i=i+1;
		
		print("^^^^ just trying to print anything");
		print("here's the value of i");
		print(i);
		if(i==updatePic.listWords.Count){
			SceneManager.LoadScene("foodSelection");
		}
		else{
		
		string frenchFromButton = updatePic.listWords[i];
		print("here's the French " +french[frenchFromButton]);
		string Englishwords = wordList[french[frenchFromButton]];
		
		//english list of selected word
		//english_words.Add(Englishwords);
		english_words.Add(Englishwords);
		print("here's the value of array size english_words");
		print(english_words.Count -1);
		print("!!!!!!show Englishwords" +Englishwords);
		
		
		print("!!!!!!compare French" +frenchFromButton);
		setFrenchText(frenchFromButton);
		sayHi( Englishwords, true);
		}
		
	}
	
	public void playS(){
		FindObjectOfType<audioManager>().playSound(wordList[french[updatePic.listWords[i]]],sounds );
		//FindObjectOfType<audioManager>().playSound(englishPic,sounds);
	}
	public void printhi(){
		print("hi");
	}

    // Update is called once per frame
    
}
