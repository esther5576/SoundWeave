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

		private FMOD.Studio.ParameterInstance _varSound;

		private FMOD.Studio.EventInstance _event;

		[Range (0, 10)]
		public float value;

		public Transform player;
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
			float val = player.transform.position.y;
			float valCalculated = (float)val * 0.01f;
			value = valCalculated;
			_varSound.setValue (value);

		}
	}
}