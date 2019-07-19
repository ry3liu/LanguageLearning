using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instantButton : MonoBehaviour
{
	GameObject canvas;
	public GameObject one;
	GameObject each;
    // Start is called before the first frame update
    public void generatePreFab(string buttonText, RectTransform previous, float additional)
    {
		canvas = GameObject.Find("Canvas");
		each = Instantiate(one);
		each.transform.SetParent(canvas.transform);
		each.GetComponent<RectTransform>().anchoredPosition = new Vector2(previous.rect.x, previous.rect.x + previous.rect.height+ additional);
		print(each.name);
		print(each.GetComponent<RectTransform>().rect.height);
		//each.GetComponent<Button>().onClick.AddListener(OnClick);
		
		each.GetComponentInChildren<Text>().text = buttonText;
		
		each.GetComponent<Button>().onClick.AddListener(delegate {printButton(each.GetComponentInChildren<Text>().text);});
        
    }
	
	private void printButton(string text){
		print("here we're printing the text in the button" + text);
		Destroy();
	}
	
	void OnClick(){
		Destroy(each);
	}

    // Update is called once per frame
   
}
