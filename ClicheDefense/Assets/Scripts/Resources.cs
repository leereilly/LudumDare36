using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

	[SerializeField] private float _CurrentHealth; //Amount of health points each creature has
	[SerializeField] private int _CurrentGold; //This is the amount of gold they give on death
	[SerializeField] public GameObject _prefab;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		RayCastMousePosition ();
	}
		

	void RayCastMousePosition()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 300)) 
		{
			Debug.DrawLine (ray.origin, hit.point, Color.cyan,1,true);

			if (hit.collider.tag == "Land") 
			{
				if (Input.GetMouseButton (0)) 
				{
					Instantiate (_prefab, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
					Destroy (hit.collider.gameObject);
					Debug.Log ("Hit land!");
				}
			}
		}
	}

}
