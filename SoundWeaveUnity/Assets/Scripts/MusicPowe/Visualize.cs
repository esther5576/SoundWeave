using UnityEngine;
using System.Collections;

public class Visualize : MonoBehaviour {
	
	public int _detail = 500;
	public float _minValue = 1.0f;
	public float _amplitude = 0.1f;

	[Range(0.5f,1.5f)]
	public float _randomAmplitude = 1.0f;

	public Vector3 _startScale;


	// Use this for initialization
	void Start () {
		_startScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		float[] _info = new float[_detail];
		AudioListener.GetOutputData (_info, 0);
		float _packageData = 0.0f;

		for(int x = 0; x < _info.Length; x++)
		{
			_packageData += System.Math.Abs (_info[x]);
		}

		transform.localScale = new Vector3 (_minValue, (_packageData * _amplitude * _randomAmplitude)+ _startScale.y, _minValue);
	}
	
}