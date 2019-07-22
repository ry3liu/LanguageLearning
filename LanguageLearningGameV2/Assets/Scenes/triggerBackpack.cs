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
	GameObject canvas;
	List <GameObject> hi = new List<GameObject>();
	Toggle eachChild;
	
	public scriptA callAnotherFunction;
	public mouseDrag mouse;
	public Audio [] soundFeedback = new Audio[3];
	GameObject spriteOne;
	GameObject cabin;
	private List<string> found;
	SpriteRenderer once;
	private Vector2 addLocation;
	GameObject sampleToggle;
	float toggle_distance;
	
	Sprite pic;
	//0 is cheer and 1 is sad. 
	
	void Start()
    {
		canvas = GameObject.Find("Canvas");
		spriteOne = GameObject.Find("cauliflower");
		cabin = GameObject.Find("cabin-inside");
		//sampleToggle = GameObject.Find("Toggle");
		sampleToggle = (GameObject)Resources.Load("Toggle");
		//hi = canvas.GetComponentsInChildren<Toggle> ();
		addLocation= new Vector2(-3.2f, 1.2f);
		toggle_distance= 20f;
		
        if (switchList == 1) {
			items =storeWord.english_words;
			//items = new List<string> {"cauliflower", "bellpepper", "eggplant", "scallops"};
			nounList = new List<string> {"la framboise", "le medicine"};
			print(items[0]);
		} else if (switchList == 2) {
			items = new List<string> {"meat", "tomato", "medicine", "scarf"};// will change the number of items later
		}
		
		FindObjectOfType<audioManager>().setSound("cheering",soundFeedback);
		FindObjectOfType<audioManager>().setSound("sympathy",soundFeedback);
		
		print(soundFeedback[0].name);
		print(soundFeedback[1].name);
		
	
	//SceneManager.LoadScene(items[0]);
        words.text = items[0];
		/*
		storeWord.english_words.Add("cauliflower");
		storeWord.english_words.Add("bellpepper");
		storeWord.english_words.Add("eggplant");
		storeWord.english_words.Add("scallops");
		*/
		
    print("calling picture prefab");
	foreach(string eachOne in items){
		//print("printing item from list");
		//print(eachOne);
		
	generateSpritePreFab(cabin,eachOne );
	generateTogglePreFab(canvas,eachOne );
	}
		
    }

	
	void OnTriggerEnter2D(Collider2D col) {
		mouse = (mouseDrag)col.GetComponent(typeof(mouseDrag));
		
		print("let see if the collision is right");
		
		print(col.gameObject.name);
		print(items[0]);
		
		if(col.gameObject.name==items[0]){
			Debug.Log("working");
			Debug.Log("game object is "+ col.gameObject); //print out the name of the sprite, on the top most.
			Debug.Log("name of object "+ col.gameObject.name); //print out the name of the sprite, on the top most., not name of image
			print(col.name);
			col.gameObject.GetComponent<Renderer>().enabled = false;
			FindObjectOfType<audioManager>().playSound("cheering",soundFeedback);
			callAnotherFunction.printSTH("good jobsss");
			print("hi each time");
			
			foreach(GameObject eachToggle in hi){
			
			eachChild = eachToggle.GetComponent<Toggle>();
			
			childToggleText = eachChild.GetComponentInChildren<Text>();
			print("^^^^ show toggle text");
			print(childToggleText.text);
			if(childToggleText.text==items[0]){
				eachChild.isOn = true;
			}
			
		}
			
			
			if(items.Count !=1){
			items.RemoveAt(0);
			//nounList.RemoveAt(0);
			}
			else{
				SceneManager.LoadScene("recognizeWords");
			}
			
			//words.text = nounList[0];
			words.text = items[0];
			//print(words.text);
			//print(items[0]);
		}
		else{
			print("wrong object");
			FindObjectOfType<audioManager>().playSound("sympathy",soundFeedback);
			callAnotherFunction.printSTH("try again");
			print(col.name);
			mouse.goback();
		}
		
		
		
	}
	  public void generateSpritePreFab(GameObject parent, string picName)
    {
		
		 GameObject hey = Instantiate(spriteOne) as GameObject;
		 hey.name = picName;
		//listToStore.Add(hey);
		//print(i);
		hey.transform.SetParent(parent.transform);
		//hey.GetComponent<RectTransform>().anchoredPosition = new Vector2(previous.rect.x, previous.rect.x + previous.rect.height+ additional);
		print(hey.name);
		
		hey.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
		hey.transform.position = new Vector3( addLocation.x,  addLocation.y, 0);
		
		once = hey.GetComponent<SpriteRenderer>();
		once.size=new Vector2(1,1);
		
		//print(wordList["Les coquilles Saint-Jacques"]);
		
		
		//manage the upper and lower case.
		//works
		//pic = Resources.Load<Sprite>(wordList[french[found[0]]]);
		//pic = Resources.Load<Sprite>(storeWord.english_words[i]);
		pic = Resources.Load<Sprite>(picName);
		once.sprite = pic;
		print(once.sprite.rect.width * 0.01);
		print(once.sprite.rect.height * 0.01);
		//addLocation = addLocation + new Vector2(2.4f, -1.4f);
		//addLocation = addLocation + new Vector2(once.sprite.rect.width* 0.001f, -(once.sprite.rect.height* 0.001f));
		addLocation = addLocation + new Vector2((once.sprite.rect.width* 0.0007f) +0.03f, 0);
        
    }
	
	
	public void generateTogglePreFab(GameObject parent, string picName)
    {
		
		 GameObject hey = Instantiate(sampleToggle) as GameObject;
		 hey.name = picName;
		 Vector2 parentPos = sampleToggle.GetComponent<RectTransform>().anchoredPosition;
		//listToStore.Add(hey);
		//print(i);
		hey.transform.SetParent(parent.transform);
		//hey.GetComponent<RectTransform>().anchoredPosition = new Vector2(previous.rect.x, previous.rect.x + previous.rect.height+ additional);
		print(hey.name);
		hey.GetComponent<Toggle>().isOn = false;
		
		hi.Add(hey); 
		
		hey.GetComponent<RectTransform>().anchoredPosition = new Vector2(parentPos.x, parentPos.y + toggle_distance);
		hey.GetComponentInChildren<Text>().text = picName;
		
		toggle_distance = toggle_distance-30f;
		
	
        
    }
	
	
    // Update is called once per frame
    
}
