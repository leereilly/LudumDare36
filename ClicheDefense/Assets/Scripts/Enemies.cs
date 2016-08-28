using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour 
{
	public float _HealthPoints; //Amount of health points each creature has
	public int _GoldAmount; //This is the amount of gold they give on death

	private NavMeshAgent _Agent;
	[SerializeField] private Vector3 TargetDestination;

	// Use this for initialization

	// Use this for initialization
	void Start ()
	{
		_Agent = GetComponent<NavMeshAgent> ();
		_Agent.SetDestination (TargetDestination);

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (_HealthPoints < 0) { OnDeath (); }

		//_Agent.SetDestination (TargetDestination);
		Debug.Log (TargetDestination.ToString ());
	}

	void SetTargetDestination(Vector3 Destination)
	{
		TargetDestination = Destination;
	}

	public void OnDeath()
	{


		GameObject.Find ("Canvas").GetComponent<Resources> ().AddGold (_GoldAmount);
		Debug.Log ("Creature is dead");
		Destroy (this.gameObject);
	}
}
