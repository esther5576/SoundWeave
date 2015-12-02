using UnityEngine;
using System.Collections;

public class ActivationV2 : MonoBehaviour
{

	public AudioSource mySource;

	// Use this for initialization
	void Start ()
	{
	
		mySource = this.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log (mySource.time);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "cube") {

			AudioSource otherSource;
			otherSource = other.GetComponent<AudioSource> ();
			otherSource.clip = mySource.clip;
			otherSource.PlayScheduled (mySource.timeSamples);
			//otherSource.PlayDelayed (mySource.time);
			//otherSource.Play();
			//otherSource = mySource;

			other.transform.GetComponent<VisualizeV2> ().enabled = true;
			//other.transform.GetComponent<MeshRenderer>().enabled = true;
			other.GetComponent<VisualizeV2> ()._trackNumber = this.GetComponent<SoundOutpu> ().newSong;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "cube") {
			other.transform.GetComponent<VisualizeV2> ()._activation = true;
		}
	}
}
