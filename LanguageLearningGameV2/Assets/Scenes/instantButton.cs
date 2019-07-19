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
    void Start()
    {
		canvas = GameObject.Find("Canvas");
		each = Instantiate(one);
		each.transform.SetParent(canvas.transform);
		each.GetComponent<RectTransform>().anchoredPosition = new Vector2(-180, 45);
		print(each.name);
		each.GetComponent<Button>().onClick.AddListener(OnClick);
		
		
        
    }
	
	void OnClick(){
		Destroy(each);
	}

    // Update is called once per frame
   
}
