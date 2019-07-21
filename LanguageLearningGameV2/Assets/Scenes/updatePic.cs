using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class updatePic : MonoBehaviour
{
	
	public storeWord one;
	public static List<string> listWords = new List<string>();
	GameObject buttonUI;
	

	
    // Start is called before the first frame update
    IEnumerator Start()
    {
		one= GameObject.Find("GameObject").GetComponent<storeWord>();
		buttonUI = GameObject.Find("soundButton");
		//buttonUI.SetActive(false);
		yield return new WaitForEndOfFrame();
		//one.sayHi(storeWord.word);
        print("here's the value of i");
		print(storeWord.i);
		//print(one.english_words[1]);
		//print(one.wordReturn());
		
		print(storeWord.word);//accessing static variable
		
		yield return null;
		//one.callWordsImage(storeWord.word);
		//generating pictures
		
		
    }

	
   
}
