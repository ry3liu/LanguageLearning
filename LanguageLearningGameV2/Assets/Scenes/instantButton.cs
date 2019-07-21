using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class instantButton : MonoBehaviour
{
	GameObject canvas;
	public GameObject one;
	GameObject each;
	GameObject panel ;
	GameObject buttonFinish;
	
	List<GameObject> listWordButton = new List<GameObject>();
	int i = 0;
	string eachOne;
	float addition = 0f;
	
	void Start(){
		panel = GameObject.Find("Panel");
		each = GameObject.Find("Canvas");
		buttonFinish = GameObject.Find("finishButton");
		buttonFinish.SetActive(false);
	}
	
	
    // Start is called before the first frame update
    public void generatePreFab(string buttonText, RectTransform previous, float additional, GameObject parent, string command, List<GameObject> listToStore)
    {
		
		 GameObject hey = Instantiate(one) as GameObject;
		listToStore.Add(hey);
		//print(i);
		hey.transform.SetParent(parent.transform);
		hey.GetComponent<RectTransform>().anchoredPosition = new Vector2(previous.rect.x, previous.rect.x + previous.rect.height+ additional);
		print(hey.name);
		print(hey.GetComponent<RectTransform>().rect.height);
		//each.GetComponent<Button>().onClick.AddListener(OnClick);
		print("print name sent to button " + buttonText);
		//eachOne= hey.GetComponentInChildren<Text>().text;
		//eachOne	= buttonText;
		hey.GetComponentInChildren<Text>().text= buttonText;
		
		if(command == "input")
		{
			hey.GetComponent<Button>().onClick.AddListener(delegate {printButton(hey.GetComponentInChildren<Text>().text, listToStore);});
	}
		else if(command == "showButton"){
			print("create another button");
			hey.GetComponent<Button>().onClick.AddListener(delegate {buttonWord(hey.GetComponentInChildren<Text>().text, hey);});
			print("showButton works"+ hey.name);
			foreach(GameObject game in listToStore){
			print(game.name);
			}
		}
		//i=i+1;
        
    }
	
	private void printButton(string text, List<GameObject> list){
		print("here we're printing the text in the button " + text);
		updatePic.listWords.Add(text);
		
		foreach(GameObject game in list){
		Destroy(game);
		}
		
		//foreach(string texting in updatePic.listWords){
		//print("here's each one in the list "+ updatePic.listWords.Count+ " "+ texting);}
		
		for(int k =0; k<updatePic.listWords.Count; k++){
			print("here's each one in the list "+ updatePic.listWords.Count+ " and the number is "+ k+ updatePic.listWords[k]);
		}
		
		generatePreFab(text, panel.GetComponent<RectTransform>(), addition, panel,"showButton", listWordButton);
		addition = addition +30;
		
		if(listWordButton.Count>1){
			buttonFinish.SetActive(true);
		}
	}
	
	private void buttonWord(string wordText, GameObject thisOne){
		print("before destryoing button");
		for(int k =0; k<updatePic.listWords.Count; k++){
			print("here's each one in the list "+ updatePic.listWords.Count+ " and the number is "+ k+ updatePic.listWords[k]);
		}
		Destroy(thisOne);
		updatePic.listWords.Remove(wordText);
		
		print("after destryoing button");
		for(int k =0; k<updatePic.listWords.Count; k++){
			print("here's each one in the list "+ updatePic.listWords.Count+ " and the number is "+ k+ updatePic.listWords[k]);
		}
		
	}
	
	public void OnClick(){
		print("here button is active and clickable");
		
		SceneManager.LoadScene("medicine");
		
	}

    // Update is called once per frame
   
}
