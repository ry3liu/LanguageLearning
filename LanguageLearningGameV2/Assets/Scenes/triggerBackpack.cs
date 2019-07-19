using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class triggerBackpack : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> items;
	public List<string> nounList;
	public int switchList =1;
	public Text words;
	public Button backpack;
	Text childToggleText;
	Canvas canvas;
	Toggle[] hi;
	Toggle eachChild;
	public scriptA callAnotherFunction;
	public mouseDrag mouse;
	
	
	void Start()
    {
		canvas = GameObject.FindGameObjectWithTag("mainCanvas").GetComponent<Canvas>();
		hi = canvas.GetComponentsInChildren<Toggle> ();
		
        if (switchList == 1) {
			
			items = new List<string> {"tomate", "meat","rasberry","cauliflower"};
			nounList = new List<string> {"la framboise", "le medicine"};
			print(items[0]);
		} else if (switchList == 2) {
			items = new List<string> {"meat", "tomato", "medicine", "scarf"};// will change the number of items later
		}
	
	//SceneManager.LoadScene(items[0]);
        words.text = items[0];
    
		
    }

	
	void OnTriggerEnter2D(Collider2D col) {
		mouse = (mouseDrag)col.GetComponent(typeof(mouseDrag));
		
		if(col.gameObject.name==items[0]){
			Debug.Log("working");
			Debug.Log("game object is "+ col.gameObject); //print out the name of the sprite, on the top most.
			Debug.Log("name of object "+ col.gameObject.name); //print out the name of the sprite, on the top most., not name of image
			print(col.name);
			col.gameObject.GetComponent<Renderer>().enabled = false;
			callAnotherFunction.printSTH("good jobsss");
			print("hi each time");
			
			for(int i=0; i< hi.Length; i++){
			
			eachChild = hi[i];
			childToggleText = eachChild.GetComponentInChildren<Text>();
			if(childToggleText.text==items[0]){
				eachChild.isOn = true;
			}
			
		}
			
			
			if(items.Count !=1){
			items.RemoveAt(0);
			//nounList.RemoveAt(0);
			}
			
			//words.text = nounList[0];
			words.text = items[0];
			print(words.text);
			//print(items[0]);
		}
		else{
			print("wrong object");
			callAnotherFunction.printSTH("try again");
			print(col.name);
			mouse.goback();
		}
		
		
		
	}
	
    // Update is called once per frame
    
}
