using UnityEngine;
using System.Collections;

public class CubeCameraOcclusion : MonoBehaviour {

	GameObject m_pPlayer;

	public float m_fDistanceOcclusionThreshold = 5f;
	bool m_bOcclusion;

	// Use this for initialization
	void Start () {
	
		m_pPlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	

		if(Vector3.Distance(GetCameraScreenPos(), GetCubeScreenPos()) < Vector3.Distance(GetCameraScreenPos(), GetPlayerScreenPos()))
		{
			if(GetCubeScreenPos().x > 0.4f && GetCubeScreenPos().y > 0.4f && GetCubeScreenPos().x < 0.6f && GetCubeScreenPos().y < 0.6f)
			{
				if(!m_bOcclusion)
				{
					SetOcclusion();
					m_bOcclusion = true;
				}

			}
			else if(GetCubeScreenPos().z < 4f)
			{
				if(!m_bOcclusion)
				{
					SetOcclusion();
					m_bOcclusion = true;
				}
			}
			else
			{
				if(m_bOcclusion)
				{
					SetNonOcclusion();
					m_bOcclusion = false;
				}
			}
		}
		/*else
		{
			if(m_bOcclusion)
			{
				SetNonOcclusion();
				m_bOcclusion = false;
			}
		}*/

			


	}

	Vector3 GetPlayerScreenPos()
	{
		Vector3 _vPlayerCurrentPos = m_pPlayer.transform.position;
		Vector3 _vScreenPos = Camera.main.WorldToViewportPoint(_vPlayerCurrentPos);

		return _vScreenPos;
	}

	Vector3 GetCubeScreenPos()
	{
		Vector3 _vCubeCurrentPos = this.transform.position;
		Vector3 _vScreenPos = Camera.main.WorldToViewportPoint(_vCubeCurrentPos);
		
		return _vScreenPos;
	}

	Vector3 GetCameraScreenPos()
	{
		Vector3 _vCamCurrentPos = Camera.main.transform.position;
		Vector3 _vScreenPos = Camera.main.WorldToViewportPoint(_vCamCurrentPos);
		
		return _vScreenPos;
	}

	bool SetOcclusion()
	{
		bool _bOccluded = true;
		if(_bOccluded)
		{
			GetComponent<Renderer>().material.color = new Vector4(1,1,1,0.1f);
			Debug.Log("lol");
			_bOccluded = false;
		}
		return _bOccluded;
	}

	bool SetNonOcclusion()
	{
		bool _bOccluded = false;
		if(!_bOccluded)
		{
			GetComponent<Renderer>().material.color = new Vector4(1,1,1,1f);
			Debug.Log("lol2");
			_bOccluded = true;
		}
		return _bOccluded;
	}

}



