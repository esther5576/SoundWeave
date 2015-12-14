using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PPTLikeSlides : MonoBehaviour {

	public List<Sprite> _Slides = new List<Sprite>(); 
	public GameObject _SlidePPT;
	public int _counter;
	public GameObject _canvas;

	void Start()
	{
		_canvas.GetComponent<CanvasGroup>().alpha = 1;
		_canvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
		_canvas.GetComponent<CanvasGroup>().interactable = true;
	}

	// Update is called once per frame
	void Update () 
	{
	

		if(Input.GetMouseButtonDown(1) && (_counter - 1) >= 0)
		{
			_counter --;
			_SlidePPT.GetComponent<Image>().sprite = _Slides[_counter];
		}

		if(Input.GetMouseButtonDown(0) && (_counter + 1) < _Slides.Count)
		{
			_counter ++;
			_SlidePPT.GetComponent<Image>().sprite = _Slides[_counter];
		}
		else if(Input.GetMouseButtonDown(0) && (_counter + 1) == _Slides.Count)
		{
			//END OF EVENT
			Debug.Log("End");
			_counter = 0;
			_canvas.GetComponent<CanvasGroup>().alpha = 0;
			_canvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
			_canvas.GetComponent<CanvasGroup>().interactable = false;
			this.enabled = false;
		}
	}
}
