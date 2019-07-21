using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]

public class Audio
{
    // Start is called before the first frame update
	public string name;
    public AudioClip sound;
	[Range(0f, 1f)]
	public float volume;
	[HideInInspector]
	public AudioSource audioSource;
}
