using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour
{
	[SerializeField]
	private Transform medicine;
	private Vector2 initialPosition;
	private Vector2 mousePosition;
	private float deltaX, deltaY;
	private float x, y;
	
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
		x=transform.position.x;
		y=transform.position.y;
    }
	
	private void OnMouseDown(){
		deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
		deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
	}
	
	private void OnMouseDrag(){
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position= new Vector2(mousePosition.x - deltaX , mousePosition.y-deltaY);
	}
    // Update is called once per frame
	
	public void goback(){
		StartCoroutine("move");
		print(x +"," +y);
		print(initialPosition);
	}
	public void printsth (){
		print("hi");
	}
    IEnumerator move(){
		yield return new WaitForSeconds(2);
		transform.position=new Vector2(x,y);
	}
}
