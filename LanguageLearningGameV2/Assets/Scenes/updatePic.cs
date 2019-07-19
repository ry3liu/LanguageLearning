using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatePic : MonoBehaviour
{
	
	public storeWord one;
	

	
    // Start is called before the first frame update
    IEnumerator Start()
    {
		one= GameObject.Find("GameObject").GetComponent<storeWord>();
		yield return new WaitForEndOfFrame();
		one.sayHi(storeWord.word);
        print(one.wordList["Les coquilles Saint-Jacques"]);
		print(one.english_words[1]);
		//print(one.wordReturn());
		
		print(storeWord.word);//accessing static variable
		
		yield return null;
		//one.callWordsImage(storeWord.word);
		
		
    }

   
}
