using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptA : MonoBehaviour
{
	public GameObject textShow;
	Text sometext;
	
    // Start is called before the first frame update
    void Start()
    {
       textShow.SetActive(false);
	   sometext = textShow.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    public void printSTH(string words){
		
		sometext.text = words;
		print(sometext.text);
		textShow.SetActive(true);
		StartCoroutine("wait");
	}
	
	
	IEnumerator wait(){
		yield return new WaitForSeconds(1.5f);
		textShow.SetActive(false);
	}
}
