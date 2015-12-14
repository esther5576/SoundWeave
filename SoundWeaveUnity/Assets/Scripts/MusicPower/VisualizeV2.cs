using UnityEngine;
using System.Collections;

public class VisualizeV2 : MonoBehaviour
{

	public float[] _spectrum;
	[Range(1,20)]
	public int
		_range = 1;

	public bool _activation;

	public AudioSource mySource;

	public int _trackNumber;

	public float _time = 10;
	public float _totalTime = 10;

	// Use this for initialization
	void Start ()
	{
		mySource = this.GetComponent<AudioSource> ();
		_range = (int)Random.Range (1, 21);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//analyse unique du son que le cube produit
		//_spectrum = mySource.GetSpectrumData (1024, 0, FFTWindow.BlackmanHarris);
		//analyse de tout ce qui peut etre entendu
		_spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);

		//Monter et descendre
		Vector3 _previousScale = this.transform.localScale;
		_previousScale.y = (Mathf.Lerp (_previousScale.y, _spectrum [_range] * 5.0f, Time.deltaTime * 10.0f)) + 0.5f;
		_previousScale.x = (Mathf.Lerp (_previousScale.x, _spectrum [_range] * 5.0f, Time.deltaTime * 50.0f)) + 0.5f;
		_previousScale.z = (Mathf.Lerp (_previousScale.z, _spectrum [_range] * 5.0f, Time.deltaTime * 50.0f)) + 0.5f;
		this.transform.localScale = _previousScale;
		//this.transform.position = new Vector3 (this.transform.position.x, this.transform.localScale.y / 2, this.transform.position.z);

		//Changer couleur
		//gameObject.GetComponent<Renderer> ().material.color = new Color (_spectrum [_range - 1] * 100, _spectrum [_range] * 100, _spectrum [_range + 1] * 100, 1);
		//gameObject.GetComponent<Renderer> ().material.color = new Color ((_spectrum [_range - 1] + _trackNumber) * 10, (_spectrum [_range] + _trackNumber) * 10, (_spectrum [_range + 1] + _trackNumber) * 10, 1);
		if (_trackNumber == 0) {
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
		}
		if (_trackNumber == 1) {
			gameObject.GetComponent<Renderer> ().material.color = Color.black;
		}
		if (_trackNumber == 2) {
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		}
		if (_trackNumber == 3) {
			gameObject.GetComponent<Renderer> ().material.color = Color.blue;
		}
		if (_trackNumber == 4) {
			gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
		}
		if (_trackNumber == 5) {
			gameObject.GetComponent<Renderer> ().material.color = Color.magenta;
		}
		if (_trackNumber == 6) {
			gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
		}
		if (_trackNumber == 7) {
			gameObject.GetComponent<Renderer> ().material.color = Color.grey;
		}

		if (_activation == true && _time <= _totalTime) {
			_time -= Time.deltaTime;
		}

		if (_activation == true && _time <= 0) {
			_activation = false;
			mySource.Stop ();
			mySource.clip = null;
			gameObject.GetComponent<Renderer> ().material.color = Color.white;
			this.GetComponent<VisualizeV2> ().enabled = false;
		}

		if (_activation == false && _time != _totalTime) {
			_time = _totalTime;
			mySource.clip = null;
			gameObject.GetComponent<Renderer> ().material.color = Color.white;
			this.GetComponent<VisualizeV2> ().enabled = false;
		}
	}



	/*public void stopMyCoroutine ()
	{
		StopCoroutine (MyMethod ());
		_activation = false;
	}

	IEnumerator MyMethod ()
	{
		Debug.Log ("restart");
		yield return new WaitForSeconds (10);
		_activation = false;
		mySource.Stop ();
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
		this.GetComponent<VisualizeV2> ().enabled = false;

	}*/
}
