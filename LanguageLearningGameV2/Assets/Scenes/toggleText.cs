using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleText : MonoBehaviour
{
    // Start is called before the first frame update
	 Toggle [] childrenList;
	 List<string> iten;
	 Toggle eachChild;
	
	public Text [] hi;
	Text childToggleText;
	int i;
	
	
    void Start()
    {
		/* iten = new List<string> {"tomate", "meat","rasberry","cauliflower"};
        childrenList = GetComponentsInChildren<Toggle> ();
		//hi = gameObject.GetComponentInChildren<Text>();
		for(i=0; i< iten.Count; i++){
			childrenList[i].isOn = false;
			eachChild = childrenList[i];
			childToggleText = eachChild.GetComponentInChildren<Text>();
			childToggleText.text = iten[i];
		}
		*/
    }

    // Update is called once per frame
  
}
