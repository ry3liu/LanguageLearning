using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chooseText : MonoBehaviour
{
	
	private string typeIn ;
	public storeWord each;
	
	
	
	public void onTextChanged(string enters){
		//showText = GetComponentInChildren<Text>();
		//showText.text = enters;
		//print(showText.text);
		print(enters);
		each.callWordsImage(enters);
		
		
		
		//SceneManager.LoadScene("medicine");
		
	}
	
	public string returnEntered(string argument){
		return argument;
	}

    // Update is called once per frame
  
}
