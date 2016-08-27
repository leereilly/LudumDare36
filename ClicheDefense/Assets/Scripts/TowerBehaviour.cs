using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerBehaviour : MonoBehaviour 
{

	[SerializeField] List<GameObject> _Enemies; 

	[SerializeField] GameObject _bulletPrefab;
	[SerializeField] float _AttackSpeed;
	[SerializeField] float _Damage;


	private bool _RoutineHandle = false;

	// Use this for initialization
	void Start () 
	{
		
		_Enemies = new List<GameObject> ();
		//StartCoroutine ("ShootBullet");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!_RoutineHandle)
			StartCoroutine (ShootBullet ());
		//ShootBullet();
	}

	IEnumerator ShootBullet()
	{
		_RoutineHandle = true;
		Debug.Log ("Bullet Created");

		GameObject bullet = Instantiate (_bulletPrefab, this.transform.position, this.transform.rotation);
		Bullet _bulletcomp = bullet.GetComponent<Bullet> ();


		yield return new WaitForSeconds (_AttackSpeed);
		_RoutineHandle = false;
	}



	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			_Enemies.Add (other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			_Enemies.Remove (other.gameObject);
		}
	}
}
