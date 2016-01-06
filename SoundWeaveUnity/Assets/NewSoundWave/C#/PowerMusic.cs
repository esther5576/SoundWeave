using UnityEngine;
using System;
using System.Collections.Generic;

namespace FMODUnity
{
	[AddComponentMenu ("FMOD Studio/PowerMusic")]
	public class PowerMusic : MonoBehaviour
	{

		[EventRef]
		public String _EventGrow;
		private FMOD.Studio.EventInstance _eventGrow;

		[EventRef]
		public String _EventHeight;
		private FMOD.Studio.EventInstance _eventHeight;

		[EventRef]
		public String _EventSplit;
		private FMOD.Studio.EventInstance _eventSplit;

		[EventRef]
		public String _EventPush;
		private FMOD.Studio.EventInstance _eventPush;

		[EventRef]
		public String _EventJump;
		private FMOD.Studio.EventInstance _eventJump;
		public String Parameter_nameJump;
		private FMOD.Studio.ParameterInstance _varSoundJump;
		public float _jumpValue;


		public GameObject player;
		public GameObject player_scripts;
		public bool TriggerLeft;
		public bool TriggerRight;
		// Use this for initialization
		void Start ()
		{
			_eventGrow = FMODUnity.RuntimeManager.CreateInstance (_EventGrow);
			_eventHeight = FMODUnity.RuntimeManager.CreateInstance (_EventHeight);
			_eventSplit = FMODUnity.RuntimeManager.CreateInstance (_EventSplit);
			_eventPush = FMODUnity.RuntimeManager.CreateInstance (_EventPush);
			_eventJump = FMODUnity.RuntimeManager.CreateInstance (_EventJump);

			_eventJump = FMODUnity.RuntimeManager.CreateInstance (_EventJump);
			_eventJump.getParameter (Parameter_nameJump, out _varSoundJump);
		}
	
		// Update is called once per frame
		void Update ()
		{
			//grow
			if (Input.GetKeyDown (KeyCode.Joystick1Button2)) {
				//PERMET D'UPDATE LA POSITION DU SON AVEC CELLE DU PERSO UNIQUEMENT LA OU J'AI LANCÉ LE SON
				//_event.set3DAttributes (RuntimeUtils.To3DAttributes (player));
				_eventGrow.start ();
			}
			if (Input.GetKeyUp (KeyCode.Joystick1Button2)) {
				_eventGrow.stop (FMOD.Studio.STOP_MODE.IMMEDIATE);
			}

			//Height
			if (Input.GetKeyDown (KeyCode.Joystick1Button0)) {
				_eventHeight.start ();
			}
			if (Input.GetKeyUp (KeyCode.Joystick1Button0)) {
				_eventHeight.stop (FMOD.Studio.STOP_MODE.IMMEDIATE);
			}

			if (Input.GetAxis ("LeftPaddleTrigger") > 0.5 && TriggerLeft == false) {
				TriggerLeft = true;
				_eventPush.start ();
			}
			if (Input.GetAxis ("LeftPaddleTrigger") < 0.1 && TriggerLeft == true) {
				TriggerLeft = false;
				//_eventPush.stop (FMOD.Studio.STOP_MODE.IMMEDIATE);
			}
			if (Input.GetAxis ("RightPaddleTrigger") > 0.5 && TriggerRight == false) {
				TriggerRight = true;
				_eventSplit.start ();
			}
			if (Input.GetAxis ("RightPaddleTrigger") < 0.1 && TriggerRight == true) {
				TriggerRight = false;
				//_eventSplit.stop (FMOD.Studio.STOP_MODE.IMMEDIATE);
			}

			if (Input.GetKeyDown (KeyCode.JoystickButton5) || Input.GetKeyDown (KeyCode.JoystickButton4)) {
				_eventJump.start ();
				if (player_scripts.GetComponent<Jump> ()._Grounded == true) {
					_jumpValue = 0;
				} else if (player_scripts.GetComponent<Jump> ()._Grounded == false) {
					_jumpValue = 1;
				}
			}
			if (Input.GetKeyUp (KeyCode.JoystickButton5) || Input.GetKeyUp (KeyCode.JoystickButton4)) {
				_eventJump.stop (FMOD.Studio.STOP_MODE.IMMEDIATE);
			}

			//PERMET D'UPDATE LA POSITION DU SON AVEC CELLE DU PERSO
			_eventGrow.set3DAttributes (RuntimeUtils.To3DAttributes (player));
			_eventHeight.set3DAttributes (RuntimeUtils.To3DAttributes (player));
			_eventPush.set3DAttributes (RuntimeUtils.To3DAttributes (player));
			_eventSplit.set3DAttributes (RuntimeUtils.To3DAttributes (player));
			_eventJump.set3DAttributes (RuntimeUtils.To3DAttributes (player));

			_eventJump.set3DAttributes (RuntimeUtils.To3DAttributes (player));
			_varSoundJump.setValue (_jumpValue);
		}
	}
}