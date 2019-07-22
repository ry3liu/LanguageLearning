using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class begunGame : MonoBehaviour
{
    // Start is called before the first frame update
	
	void Start(){
		print("starting the game");
	}
	
    public void startGame(){
		SceneManager.LoadScene("introduceGame");
	}
}
