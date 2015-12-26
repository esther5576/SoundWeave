using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundOutpu : MonoBehaviour
{

	public List<AudioClip> myList = new List<AudioClip> ();
	public AudioSource mySource;
	public int newSong;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!mySource.isPlaying) {
			Debug.Log ("need new song");
			newSong = (int)Random.Range (0, 8);
			mySource.clip = myList [newSong];
			mySource.Play ();
		}
	}
}
