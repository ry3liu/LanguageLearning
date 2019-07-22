using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class threeScene : MonoBehaviour
{
    // Start is called before the first frame update
	List<string> frenchFood, frenchCold, frenchSick;
	private string[,] wordThreeInstanceFrench = new string[3,3];
	private string[,] wordThreeInstanceEnglish = new string[3,3];
	public Button []buttonListThreeScene = new Button[3];
	
	//in 2D array, food =0, cold=1, sick=2
	
	int ifrenchFood=0;
	int	ifrenchCold =0;
	int ifrenchSick=0;
	int trackNumInOverall = 0;
	
	
	
	
    void Start()
    {
        frenchFood = new List<string>{"les coquilles Saint-Jacques", "le poivron","le chou-fleur","l'aubergine"};
		frenchCold = new List<string>{"la moufle","le casque"};
		frenchSick = new List<string>{"le sparadrap", "la pilule"};
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
		
		
    }

	
	public void setFunction(){
		foreach(Button oneButton in buttonListThreeScene){
			oneButton.onClick.AddListener(delegate {buttonClickThreeScene(oneButton, nameButton[0]);});
			oneButton.GetComponentInChildren<Text>().text = nameButton[indices];
			
			
		}
	}
	
	
	public void buttonClickThreeScene(){
		
	}
	
	
    // Update is called once per frame
    
}
