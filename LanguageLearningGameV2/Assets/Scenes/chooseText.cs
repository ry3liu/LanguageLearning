using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chooseText : MonoBehaviour
{
	public Text showText;
	private string typeIn ;
	public storeWord each;
	
	private static bool entered=false;
	
	public void onTextChanged(string enters){
		showText.text = enters;
		print(showText.text);
		each.callWordsImage(showText.text);
		entered= true;
		
		//SceneManager.LoadScene("medicine");
		
	}
	
	public string returnEntered(string argument){
		return argument;
	}

    // Update is called once per frame
  
}
