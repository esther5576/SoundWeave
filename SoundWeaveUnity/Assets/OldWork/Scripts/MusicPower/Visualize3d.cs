using UnityEngine;
using System.Collections;

public class Visualize3d : MonoBehaviour {

	public float[] _spectrum;
	[Range(1,20)]
	public int _range =1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		_spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);

		Vector3 _previousScale = this.transform.localScale;

		_previousScale.y = (Mathf.Lerp (_previousScale.y, _spectrum[_range] * 40.0f, Time.deltaTime *30.0f)) + 1.0f;

		this.transform.localScale = _previousScale;

		this.transform.position = new Vector3 (this.transform.position.x, this.transform.localScale.y/2, this.transform.position.z);

		gameObject.GetComponent<Renderer>().material.color = new Color (_spectrum[_range - 1] * 10, _spectrum[_range] * 10, _spectrum[_range + 1] * 10, 1);
	}
}
