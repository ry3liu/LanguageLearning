using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class storeWord : MonoBehaviour
{
	public Dictionary<string, string> wordList = new Dictionary<string, string>();
	public List<string> english_words = new List<string>();
	private Dictionary <string, string> french = new Dictionary<string, string>();
	private List<string> found;
	
	public static string word;
	
	private static bool entered = false;
	
	SpriteRenderer one;
	Sprite pic;
	GameObject each;
	Image imagery;
	RectTransform trans;
	
    // Start is called before the first frame update
    void Start()
    {
		print("call storeWord first");
		wordList.Add("Les coquilles Saint-Jacques", "Scallops");
	wordList.Add("le poivron", "Bell pepper");
		//or words.Value
		
		foreach(KeyValuePair<string, string> words in wordList){
			english_words.Add(words.Key.ToLower());
			french.Add(words.Key.ToLower(), words.Key);
		}
		
		
    }
	
	public void callWordsSprite(string check){
		SceneManager.LoadScene("medicine");
		
		
		each = GameObject.FindWithTag("Player");
		
		print(each.name); //so it is accessing gameobject
		each.transform.localScale = new Vector3(1,1,1);
		one = each.GetComponent<SpriteRenderer>();
		one.size=new Vector2(1,1);
		
		//print(wordList["Les coquilles Saint-Jacques"]);
		found = english_words.FindAll(w=>w.StartsWith(check.ToLower()));
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
		found = english_words.FindAll(w=>w.StartsWith(check.ToLower()));
		foreach(string hi in found){
			print(hi);
			word = hi;
			
		}
		//SceneManager.LoadScene("medicine");
		
		
		//sayHi(check);
		
		
		//doesn't work 
		//one.size=new Vector2(1,1);
        
	}
	
	
	
	public void sayHi(string yo){
		print("let's see if it get executed first or not");
		//print(english_words[0]);
		
		each = GameObject.FindWithTag("Player");
		print("printing the name of image object");
		print(each.name); //so it is accessing gameobject
		//each.transform.localScale = new Vector3(1,1,1);
		imagery = each.GetComponent<Image>();
		trans = each.GetComponent<RectTransform>();
		trans.sizeDelta=new Vector2(300,300);
		
		//manage the upper and lower case.
		//works
		//pic = Resources.Load<Sprite>(wordList[french[found[0]]]);
		pic = Resources.Load<Sprite>("Cauliflower");
		imagery.sprite = pic;
		
	}
	
	public string wordReturn(){
		string yo = "Hi";
		return yo;
	}

    // Update is called once per frame
    
}
