using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	
	public storeWord instanceOfStoreWord;
	
	//in 2D array, food =0, cold=1, sick=2
	
	int ifrenchFood=0;
	int	ifrenchCold =0;
	int ifrenchSick=0;
	int trackNumInOverall = 0;
	
	int trackRow = 0;
	int trackColumn = 0;
	
	
	
    void Start()
    {
        frenchFood = new List<string>{"les coquilles Saint-Jacques", "le poivron","le chou-fleur","l'aubergine"};
		frenchCold = new List<string>{"la moufle","le casque"};
		frenchSick = new List<string>{"le sparadrap", "la pilule"};
		
		numToPic.Add(0,"man_cold");
		numToPic.Add(1,"man_hungry_need_add_food");
		numToPic.Add(2,"man_vomiting");
		
		numToWord.Add(0,"a faim");
		numToWord.Add(1,"a friod");
		numToWord.Add(2,"est blesse");
		
		numToList.Add(0,frenchFood);
		numToList.Add(1,frenchCold);
		numToList.Add(2,frenchSick);
		
		//print(numToList[0][0]);
		
		
		print(frenchFood.Contains("le sparadrap"));
		
		
		
		foreach(string frenchString in updatePic.listWords ){
			if(frenchFood.Contains(frenchString)){
				wordThreeInstanceFrench[0,ifrenchFood] = frenchString;
				wordThreeInstanceEnglish[0,ifrenchFood] = storeWord.english_words[trackNumInOverall];
				ifrenchFood = ifrenchFood+1;
			}
			else if(frenchCold.Contains(frenchString)){
				wordThreeInstanceFrench[1,ifrenchCold] = frenchString;
				wordThreeInstanceEnglish[1,ifrenchCold] = storeWord.english_words[trackNumInOverall];
				ifrenchCold = ifrenchCold+1;
			}
			else if(frenchSick.Contains(frenchString)){
				wordThreeInstanceFrench[2,ifrenchSick] = frenchString;
				wordThreeInstanceEnglish[2,ifrenchSick] = storeWord.english_words[trackNumInOverall];
				ifrenchSick = ifrenchSick+1;
			}
			
			
			trackNumInOverall = trackNumInOverall+1;
			
		}
		houseKeeperFunction(0,0);
		
    }

	
	public void setFunction(){
		foreach(Button oneButton in buttonListThreeScene){
			oneButton.onClick.AddListener(delegate {buttonClickThreeScene(oneButton.GetComponentInChildren<Text>().text);});
			//oneButton.GetComponentInChildren<Text>().text = nameButton[indices];
			
			
		}
	}
	
	
	public void buttonClickThreeScene(string buttonStr){
		print(buttonStr);
	}
	
	public void houseKeeperFunction(int typeScene, int withinScene){
		List<int> arrayNum = new List<int> {0,1,2};
		instanceOfStoreWord.sayHi(numToPic[typeScene],false);
		buttonListThreeScene[typeScene].GetComponentInChildren<Text>().text= numToList[typeScene][withinScene];
		
		arrayNum.Remove(typeScene);
		foreach(int individual in arrayNum){
			int number = Random.Range(0,2);
			buttonListThreeScene[individual].GetComponentInChildren<Text>().text= numToList[individual][number];
		}
		
		//load words
	}
	
	
    // Update is called once per frame
    
}
