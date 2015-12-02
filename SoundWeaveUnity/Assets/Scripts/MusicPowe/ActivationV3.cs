using UnityEngine;
using System.Collections;

public class ActivationV3 : MonoBehaviour
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
	
	void OnTriggerStay (Collider other)
	{
		if (other.tag == "cube") {
			Debug.Log ("collide");
			AudioSource otherSource;
			if (this.GetComponent<SoundOutputV2> ().mySource.clip != null) {
				//other.GetComponent<VisualizeV2> ().StopCoroutine (MyMethod ());

				otherSource = other.GetComponent<AudioSource> ();
				otherSource.clip = mySource.clip;
				otherSource.PlayScheduled (mySource.timeSamples);
				//otherSource.PlayDelayed (mySource.time);
				//otherSource.Play();
				//otherSource = mySource;
				
				other.transform.GetComponent<VisualizeV2> ().enabled = true;
				other.transform.GetComponent<VisualizeV2> ()._activation = false;
				//other.transform.GetComponent<MeshRenderer>().enabled = true;
				other.GetComponent<VisualizeV2> ()._trackNumber = this.GetComponent<SoundOutputV2> ().newSong;
				other.transform.GetComponent<VisualizeV2> ()._activation = true;
			}
		}
	}
	
	/*void OnTriggerExit (Collider other)
	{
		if (other.tag == "cube") {
			other.transform.GetComponent<VisualizeV2> ()._activation = true;
		}
	}*/
}
