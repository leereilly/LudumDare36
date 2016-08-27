using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

	[Range(50,200)]
	[SerializeField] private float m_speed;

	private Vector3 _pos;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		UserInput ();


		Vector3 ClampPos = transform.position;
		ClampPos.z = Mathf.Clamp (ClampPos.z, 0, 220);
		transform.position = ClampPos;

	}


	void UserInput()
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (0, 0, m_speed * Time.deltaTime,Space.World);
		}

		if (Input.GetKey (KeyCode.S))
		{
			transform.Translate (0, 0, -m_speed * Time.deltaTime,Space.World);

		}
	}

}
