using UnityEngine;
using System.Collections;

public class LoseHealthScript : MonoBehaviour {

	[SerializeField] private GameObject _Resourcemanager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			_Resourcemanager.GetComponent<Resources> ().RemoveLife ();
			Destroy (other.gameObject);
		}

	}

}
