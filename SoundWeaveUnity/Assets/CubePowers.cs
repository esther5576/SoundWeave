using UnityEngine;
using System.Collections;

public class CubePowers : MonoBehaviour {

	public float heightPower = 10.0f;
	public float maxHeight = 10.0f;
	public float minHeight = 3.0f;
	public bool heightGrowingAcive = false;
	public Vector3 positionCube;
	
	public bool biggerGrowActive = false;

	public PhysicMaterial bouncyMat;
	public float timer;
	public bool bouncyActive;

	// Use this for initialization
	void Start () {
		positionCube = new Vector3();
		positionCube = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		HeightGrow();

		BiggerGrow();

		ActiveBouncy();
	}

	void ActiveBouncy()
	{
		if(timer < 10.0f && bouncyActive == true)
		{
			timer += Time.deltaTime;
			this.GetComponent<BoxCollider>().material = bouncyMat;
		}
		if(timer >= 1.0f && bouncyActive == true)
		{
			bouncyActive = false;
			this.GetComponent<BoxCollider>().material = null;
			timer = 0;
		}

		if(bouncyActive == false)
		{
			this.GetComponent<BoxCollider>().material = null;
			timer = 0;
		}
	}

	void BiggerGrow()
	{
		if(this.transform.localScale.x < maxHeight && biggerGrowActive == true)
		{
			this.transform.localScale += new Vector3(heightPower, 0, heightPower) * Time.deltaTime;
		}
		if(this.transform.localScale.x > maxHeight && biggerGrowActive == true)
		{
			this.transform.localScale = new Vector3 (maxHeight, this.transform.localScale.y, maxHeight);
			biggerGrowActive = false;
		}
		
		if(this.transform.localScale.x > minHeight && biggerGrowActive == false)
		{
			this.transform.localScale -= new Vector3(heightPower, 0, heightPower) * Time.deltaTime;
		}
		if(this.transform.localScale.x < minHeight && biggerGrowActive == false)
		{
			this.transform.localScale = new Vector3 (minHeight, this.transform.localScale.y, minHeight);
		}
	}

	void HeightGrow()
	{
		if(this.transform.localScale.y < maxHeight && heightGrowingAcive == true)
		{
			this.transform.localScale += new Vector3(0, heightPower, 0) * Time.deltaTime;
			this.transform.position = new Vector3 (positionCube.x, positionCube.y + this.transform.localScale.y / 2, positionCube.z);
		}
		if(this.transform.localScale.y > maxHeight && heightGrowingAcive == true)
		{
			this.transform.localScale = new Vector3 (this.transform.localScale.x, maxHeight, this.transform.localScale.z);
			this.transform.position = new Vector3 (positionCube.x, positionCube.y + this.transform.localScale.y / 2, positionCube.z);
			heightGrowingAcive = false;
		}

		if(this.transform.localScale.y > minHeight && heightGrowingAcive == false)
		{
			this.transform.localScale -= new Vector3(0, heightPower, 0) * Time.deltaTime;
			this.transform.position = new Vector3 (positionCube.x, positionCube.y + this.transform.localScale.y / 2, positionCube.z);
		}
		if(this.transform.localScale.y < minHeight && heightGrowingAcive == false)
		{
			this.transform.localScale = new Vector3 (this.transform.localScale.x, minHeight, this.transform.localScale.z);
			this.transform.position = new Vector3 (positionCube.x, positionCube.y + this.transform.localScale.y / 2, positionCube.z);
			//heightGrowingAcive = true;
		}
	}
}
