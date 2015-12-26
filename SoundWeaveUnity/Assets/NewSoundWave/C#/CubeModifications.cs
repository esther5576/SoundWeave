using UnityEngine;
using System.Collections;

public class CubeModifications : MonoBehaviour
{
	#region Bigger Grow cube transformation variables
	public float MaxGrow;
	public float MinGrow;
	public bool GrowFunctionActive;
	public bool IncreaseDecrease;
	public float GrowSpeed;	
	#endregion

	#region Bigger Height cube transformation variables
	public float MaxHeight;
	public float MinHeight;
	public bool GrowHeightFunctionActive;
	public bool IncreaseDecreaseHeight;
	public float GrowHeightSpeed;	
	#endregion

	#region Turn the cube kinematic after an amount of time
	public float TotalTimerForKinematic;
	public float ActualTimerForKinematic;
	public bool ActualKinematicTimerActive;
	#endregion

	#region duplicate cubes variables
	public GameObject prefabCube;
	public bool divisionOfCubesActive;
	public float explosionForce = 100;
	public float explosionRange = 10;
	public float upwardsModifierOfExplosion = 3.0f;
	#endregion

	#region Turn the cube kinematic after an amount of time
	public float TotalTimerForKinematic2;
	public float ActualTimerForKinematic2;
	public bool ActualKinematicTimerActive2;
	#endregion

	// Update is called once per frame
	void Update ()
	{
		if (GrowFunctionActive == true) {
			BiggerGrow ();
		}

		if (GrowHeightFunctionActive == true) {
			BiggerHeight ();
		}

		if (divisionOfCubesActive == true) {
			DuplicateObject ();
		}

		#region Turn the cube Kinematic after an amount of time
		if (this.GetComponent<Rigidbody> ().isKinematic == false && ActualKinematicTimerActive == false) {
			ActualKinematicTimerActive = true;
			ActualTimerForKinematic = TotalTimerForKinematic;
		}
		if (this.GetComponent<Rigidbody> ().isKinematic == false && ActualKinematicTimerActive == true) {
			ActualTimerForKinematic -= Time.deltaTime;
			if (ActualTimerForKinematic <= 0) {
				this.GetComponent<Rigidbody> ().isKinematic = true;
				ActualKinematicTimerActive = false;
			}
		}
		#endregion

		#region Turn the cube kinematic false after an amount of time
		if (this.GetComponent<Rigidbody> ().isKinematic == true && ActualKinematicTimerActive2 == false) {
			ActualKinematicTimerActive2 = true;
			ActualTimerForKinematic2 = TotalTimerForKinematic2;
		}
		if (this.GetComponent<Rigidbody> ().isKinematic == true && ActualKinematicTimerActive2 == true) {
			ActualTimerForKinematic2 -= Time.deltaTime;
			if (ActualTimerForKinematic2 <= 0) {
				this.GetComponent<Rigidbody> ().isKinematic = false;
				ActualKinematicTimerActive2 = false;
			}
		}
		#endregion
	}

	#region Bigger Grow cube transformation
	void BiggerGrow ()
	{
		if (this.transform.localScale.x < MaxGrow && IncreaseDecrease == true) {
			this.transform.localScale += new Vector3 (GrowSpeed, 0, GrowSpeed) * Time.deltaTime;
		}
		if (this.transform.localScale.x >= MaxGrow && IncreaseDecrease == true) {
			this.transform.localScale = new Vector3 (MaxGrow, this.transform.localScale.y, MaxGrow);
			IncreaseDecrease = false;
		}
		
		if (this.transform.localScale.x > MinGrow && IncreaseDecrease == false) {
			this.transform.localScale -= new Vector3 (GrowSpeed, 0, GrowSpeed) * Time.deltaTime;
		}
		if (this.transform.localScale.x <= MinGrow && IncreaseDecrease == false) {
			this.transform.localScale = new Vector3 (MinGrow, this.transform.localScale.y, MinGrow);
			IncreaseDecrease = true;
		}
	}
	#endregion

	#region Bigger Height cube transformation
	void BiggerHeight ()
	{
		if (this.transform.localScale.y < MaxHeight && IncreaseDecreaseHeight == true) {
			this.transform.localScale += new Vector3 (0, GrowHeightSpeed, 0) * Time.deltaTime;
		}
		if (this.transform.localScale.y >= MaxHeight && IncreaseDecreaseHeight == true) {
			this.transform.localScale = new Vector3 (this.transform.localScale.x, MaxHeight, this.transform.localScale.z);
			IncreaseDecreaseHeight = false;
		}
		
		if (this.transform.localScale.y > MinHeight && IncreaseDecreaseHeight == false) {
			this.transform.localScale -= new Vector3 (0, GrowHeightSpeed, 0) * Time.deltaTime;
		}
		if (this.transform.localScale.y <= MinHeight && IncreaseDecreaseHeight == false) {
			this.transform.localScale = new Vector3 (this.transform.localScale.x, MinHeight, this.transform.localScale.z);
			IncreaseDecreaseHeight = true;
		}
	}
	#endregion

	#region Duplicate the CUBE
	void DuplicateObject ()
	{
		GameObject prefab;
		prefab = Instantiate (prefabCube, this.transform.position, this.transform.rotation) as GameObject;
		prefab.name = "CUBE";
		prefab.GetComponent<Rigidbody> ().isKinematic = false;
		prefab.GetComponent<CubeModifications> ().divisionOfCubesActive = false;
		divisionOfCubesActive = false;
		prefab.GetComponent<Rigidbody> ().AddExplosionForce (explosionForce, prefab.transform.position, explosionRange, upwardsModifierOfExplosion);

	}
	#endregion
}
