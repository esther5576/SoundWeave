using UnityEngine;
using System;
using System.Collections.Generic;


namespace FMODUnity
{
	[AddComponentMenu ("FMOD Studio/SoundWaveMusic")]
	public class SoundWaveMusic : MonoBehaviour
	{
		[EventRef]
		public String Event;
		public String Parameter_name;
		//public float maxParameterValue = 1f;
		//public float minParameterValue = 0f;

		//private float _value;

		private FMOD.Studio.ParameterInstance _varSound;

		private FMOD.Studio.EventInstance _event;
		//private FMOD.Studio.CueInstance cue;

		[Range (0, 10)]
		public float value;

		// Use this for initialization
		void Start ()
		{
			_event = FMODUnity.RuntimeManager.CreateInstance (Event);
			_event.getParameter (Parameter_name, out _varSound);
			_event.start ();
		}

		// Update is called once per frame
		void Update ()
		{
			
			/*if (Input.GetKeyDown (KeyCode.Keypad1)) {
				_event.start ();
			}

			if (Input.GetKeyDown (KeyCode.Keypad2)) {
				_event.stop (FMOD.Studio.STOP_MODE.IMMEDIATE);
			}

			if (Input.GetKey (KeyCode.Keypad4)) {
				if (_value > minParameterValue) {
					_value -= Time.deltaTime;
					_varSound.setValue (_value);
					print (_value);
				} else
					_value = minParameterValue;
			}

			if (Input.GetKey (KeyCode.Keypad5)) {
				if (_value < maxParameterValue) {
					_value += Time.deltaTime;
					_varSound.setValue (_value);
					print (_value);
				} else
					_value = maxParameterValue;

			}*/
			_varSound.setValue (value);
		}
	}
}