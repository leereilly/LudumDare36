using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	//Target to home in on
	private GameObject _Target;
	[SerializeField] private float _damage;
	[SerializeField] private float _movementspeed;


	private Vector3 TargetLastPosition;

	// Use this for initialization
	void Start () 
	{
		//StartCoroutine (DestroyBullet ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		HomeOnTarget ();
	}

	void HomeOnTarget()
	{
		float step = _movementspeed * Time.deltaTime;

		if (_Target != null) {
			//float step = _movementspeed * Time.deltaTime;
			TargetLastPosition = _Target.transform.position;
			//Debug.Log (_Target.transform.position.ToString ());
			transform.position = Vector3.MoveTowards (transform.position, _Target.transform.position, step);

		}
		else 
		{
			if (TargetLastPosition != Vector3.zero) {
				transform.position = Vector3.MoveTowards (transform.position, TargetLastPosition, step);
				StartCoroutine (DestroyBullet ());
			} 
			else 
			{
				transform.position = transform.forward * step;
				StartCoroutine (DestroyBullet ());
			}
		}
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


	IEnumerator DestroyBullet()
	{
		if (_Target == null) 
		{
			Debug.Log ("Destroying bullet");
			yield return new WaitForSeconds (.20f);
			Destroy (this.gameObject);

		}

		//yield return new WaitForSeconds (1.0f);
		StartCoroutine (DestroyBullet ());

	}

}
