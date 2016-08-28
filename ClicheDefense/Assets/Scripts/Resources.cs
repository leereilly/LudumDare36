using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resources : MonoBehaviour {

	[SerializeField] private float _CurrentHealth; //Amount of health points each creature has
	[SerializeField] private int _CurrentGold; //This is the amount of gold they give on death

	[SerializeField] public GameObject _Moneyvalue;
	[SerializeField] public GameObject _LifeValue;
	[SerializeField] public GameObject _Selector;

	[SerializeField] public GameObject _tower1;


	private GameObject _spawnerReference;
	private bool _RoutineHandle = false;


	private GameObject _SelectedGameObject;

	[SerializeField] private GameObject _Purchasepanel;

	// Use this for initialization
	void Start ()
	{
		_spawnerReference = GameObject.Find ("Spawner");
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
				


				if (!_Purchasepanel.activeSelf) 
				{
					Vector3 Pos = hit.collider.gameObject.transform.position;
					Pos.y += .5f;

					//_Selector.transform.position = hit.collider.gameObject.transform.position;
					_Selector.transform.position = Pos;

					if (Input.GetMouseButton (0))
					{
						
						_SelectedGameObject = hit.collider.gameObject;
						_Purchasepanel.SetActive (true);
					}
				}
			}
		}
	}


	public void PurchaseTower1() 
	{
		if (_CurrentGold >= 30) 
		{

			Instantiate (_tower1, _SelectedGameObject.transform.position, _SelectedGameObject.transform.rotation);
			Destroy (_SelectedGameObject);
			_Purchasepanel.SetActive (false);
			_CurrentGold -= 30;
			_Moneyvalue.GetComponent<Text> ().text = _CurrentGold.ToString ();

			//transform.FindChild ("Moneyvalue").GetComponent<Text>().text = _CurrentGold.ToString();
		}

	}



	public void Exit()
	{
		_Purchasepanel.SetActive (false);
	}




	public void AddGold(int Value) 
	{
		_CurrentGold += Value;
		_Moneyvalue.GetComponent<Text> ().text = _CurrentGold.ToString ();
		_spawnerReference.GetComponent<Spawner> ()._CreaturesKilled += 1;
	}

	public void RemoveLife()
	{
		_CurrentHealth -= 1;
		_LifeValue.GetComponent<Text> ().text = _CurrentHealth.ToString ();

	}
		
}
