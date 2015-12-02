using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundOutputV2 : MonoBehaviour
{

	public List<AudioClip> myList = new List<AudioClip> ();
	public AudioSource mySource;
	public int newSong;
	int countLeft;
	int countRight;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Joystick1Button4)) {
			Debug.Log ("SON0");
			newSong = 0;
			mySource.clip = myList [newSong];
			mySource.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button5)) {
			Debug.Log ("SON1");
			newSong = 1;
			mySource.clip = myList [newSong];
			mySource.Play ();
		}

		//Debug.Log (Input.GetAxis ("360_Triggers"));

		if (Input.GetAxis ("360_Triggers") == -1 && countLeft == 0) {
			Debug.Log ("SON3");
			countLeft ++;

			newSong = 2;
			mySource.clip = myList [newSong];
			mySource.Play ();
		} else if (Input.GetAxis ("360_Triggers") != -1) {
			countLeft = 0;
		}

		if (Input.GetAxis ("360_Triggers") == 1 && countRight == 0) {
			Debug.Log ("SON4");
			countRight ++;

			newSong = 3;
			mySource.clip = myList [newSong];
			mySource.Play ();
		} else if (Input.GetAxis ("360_Triggers") != 1) {
			countRight = 0;
		}

		if (!mySource.isPlaying) {

			newSong = 9999;
			mySource.clip = null;
		}
	}
}
