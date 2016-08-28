using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	//Target to home in on
	[SerializeField] GameObject _Target;
	[SerializeField] private float _damage;
	[SerializeField] private float _movementspeed;




	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		HomeOnTarget ();
	}

	void HomeOnTarget()
	{
		if (_Target != null) 
		{
			float step = _movementspeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, _Target.transform.position, step);
		} 


		else
			Destroy (this.gameObject);
	}

	public void SetTarget(GameObject Target)
	{
		_Target = Target;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Enemies enemy = other.gameObject.GetComponent<Enemies> ();
			enemy._HealthPoints -= _damage;
			Destroy (this.gameObject);
		}

	}

}
