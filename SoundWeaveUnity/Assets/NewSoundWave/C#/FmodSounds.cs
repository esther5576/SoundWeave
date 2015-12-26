using UnityEngine;
using System.Collections;

public class FmodSounds : MonoBehaviour
{
	bool trigger1;
	bool trigger2;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKeyDown (KeyCode.Joystick1Button4)) {
			//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/grow", transform.localPosition);
		}
		if (Input.GetKeyDown (KeyCode.Joystick1Button5)) {
			//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/enlarge", transform.localPosition);
		}
		if (Input.GetAxis ("360_Triggers") < -0.9 && trigger1 == false) {
			//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/push", transform.localPosition);
			trigger1 = true;
		} 
		if (Input.GetAxis ("360_Triggers") > 0.9 && trigger2 == false) {
			//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/split", transform.localPosition);
			trigger2 = true;
		}
		if ((Input.GetAxis ("360_Triggers") < 0.9 && Input.GetAxis ("360_Triggers") > -0.9)) {
			trigger1 = false;
			trigger2 = false;
		}

	}
}
