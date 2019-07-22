using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class audioManager : MonoBehaviour
{
	int u;
     //Audio [] sounds = new Audio[updatePic.listWords.Count];
	 void Start(){
		//playSound("bellpepper");
		u =0;
	}
	
	//void Awake(){
		public void setSound(string eachS, Audio[]sounds){
		
		print("==========enters awake after all");
	
		
		
		//foreach(string eachS in storeWord.english_words){
			print("\n"+ eachS);
			//string eachS = "bellpepper";
			print("the current value of u is "+u);
			Audio eachSound = new Audio();
			eachSound.audioSource = gameObject.AddComponent<AudioSource>();
			
			eachSound.name = eachS;
			eachSound.audioSource.name = eachSound.name;
			
			string address = "Audio/" + eachS;
			eachSound.sound = (AudioClip)Resources.Load(address);
			eachSound.audioSource.clip = eachSound.sound;
			
			/*if(u>0){
			foreach(Audio oneSou in sounds){
				print(oneSou.name);
			}
			}
			*/
			sounds[u]=eachSound;
			print("in the audio manager function and display name" + u + " " +sounds[u].name);
			u=u+1;
			
			
		//}
	//}
	}
	
	
	public void playSound(string name, Audio[]sounds){
		print("entered play sound");
		print("name to search for: " + name);
		
		/*foreach(Audio one in sounds){
			print(one.name);
			one.audioSource.Play();
			print("&&&&  testing if : the audio names are the same");
			if(name == one.name){
				print("the audio names are the same");
				
			}
		}*/
		
		Audio oneSound = Array.Find(sounds, sound=>sound.name == name);
		print("trying to play the sound" + oneSound.name);
		oneSound.audioSource.Play();
	}
	
	
	
}
