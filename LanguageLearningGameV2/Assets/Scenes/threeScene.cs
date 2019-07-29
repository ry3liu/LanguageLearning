using System.Collections;
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
	
	Sprite pic;
	
	RectTransform trans;
	
	GameObject[] listingItem;
	
	//in 2D array, food =0, cold=1, sick=2
	
	int ifrenchFood=0;
	int	ifrenchCold =0;
	int ifrenchSick=0;
	int trackNumInOverall = 0;
	
	int trackRow = 0;
	int trackColumn = 0;
	
	
	
    void Start()
    {
		listingItem = GameObject.FindGameObjectsWithTag("itemInForest");
		wordList.Add("les coquilles Saint-Jacques", "scallops");
		wordList.Add("le poivron", "bellpepper");
		wordList.Add("le chou-fleur", "cauliflower");
		wordList.Add("l'aubergine", "eggplant");
		
		wordList.Add("la moufle", "mitten");
		wordList.Add("le sparadrap", "surgicaltape");
		
		
		wordList.Add("le casque", "helmet");
		wordList.Add("la pilule", "pill");
		
		//storeWord.printhi();
        frenchFood = new List<string>{"les coquilles Saint-Jacques", "le poivron","le chou-fleur","l'aubergine"};
		frenchCold = new List<string>{"la moufle","le casque"};
		frenchSick = new List<string>{"le sparadrap", "la pilule"};
		testExample.Add("les coquilles Saint-Jacques");
		testExample.Add("le casque");
		testExample.Add("le sparadrap");
		
		
		numToPic.Add(0,"man_cold");
		numToPic.Add(1,"man_hungry_need_add_food");
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
		
		
		
		//foreach(string frenchString in updatePic.listWords ){
		foreach(string frenchString in testExample ){
			if(frenchFood.Contains(frenchString)){
				wordThreeInstanceFrench[0,ifrenchFood] = frenchString;
				//wordThreeInstanceEnglish[0,ifrenchFood] = storeWord.english_words[trackNumInOverall];
				wordThreeInstanceEnglish[0,ifrenchFood] =wordList[frenchString];
				print(wordList[frenchString]);
				//ifrenchFood = ifrenchFood+1;
			}
			else if(frenchCold.Contains(frenchString)){
				wordThreeInstanceFrench[1,ifrenchCold] = frenchString;
				//wordThreeInstanceEnglish[1,ifrenchCold] = storeWord.english_words[trackNumInOverall];
				wordThreeInstanceEnglish[1,ifrenchFood] =wordList[frenchString];
				ifrenchCold = ifrenchCold+1;
				print(wordList[frenchString]);
			}
			else if(frenchSick.Contains(frenchString)){
				wordThreeInstanceFrench[2,ifrenchSick] = frenchString;
				wordThreeInstanceEnglish[2,ifrenchFood] =wordList[frenchString];
				//wordThreeInstanceEnglish[2,ifrenchSick] = storeWord.english_words[trackNumInOverall];
				ifrenchSick = ifrenchSick+1;
				print(wordList[frenchString]);
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
	
	public void setItemPic(int column,string[,] englishString){
		int index = 0;
		foreach(GameObject eachItem in listingItem){
			
		
		trans = eachItem.GetComponent<RectTransform>();
		trans.sizeDelta=new Vector2(150,150);
		
		//manage the upper and lower case.
		//works
		//pic = Resources.Load<Sprite>(wordList[french[found[0]]]);
		pic = Resources.Load<Sprite>(englishString[index,column]);
		eachItem.GetComponent<Image>().sprite = pic;
		
		index+=1;
		
		
		}
	}
	
	
	public void buttonClickThreeScene(string buttonStr){
		print(buttonStr);
	}
	
	public void houseKeeperFunction(int typeScene, int withinScene){
		List<int> arrayNum = new List<int> {0,1,2};
		instanceOfStoreWord.sayHi(numToPic[typeScene],false);
		instructionText.text = instruction[typeScene];
		buttonListThreeScene[typeScene].GetComponentInChildren<Text>().text= numToList[typeScene][withinScene];
		
		arrayNum.Remove(typeScene);
		foreach(int individual in arrayNum){
			int number = Random.Range(0,2);
			buttonListThreeScene[individual].GetComponentInChildren<Text>().text= numToList[individual][number];
		}
		setItemPic(0,wordThreeInstanceEnglish);
		//load words
	}
	
	
    // Update is called once per frame
    
}
