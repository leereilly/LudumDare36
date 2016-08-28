using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour 
{
	struct YouWhat
	{
		int hp;
		GameObject prefab;
	}


	[SerializeField] private float _DefaultSpawnRate;
	private bool _RoutineHandle = false;
	private bool _UpdateHandle = false;
	private bool _SpawnerEnabled = true;
	public int _CreaturesKilled = 0;

	[SerializeField] public List<float> _SpawnRates;
	[SerializeField] private GameObject _CaveMan;
	[SerializeField] private GameObject _Soldier;

	private GameObject _CurrentSpawn;

	void Start () 
	{
		_CurrentSpawn = _CaveMan;
		StartCoroutine (DelaySpawn ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine (SpawnEnemy());
		StartCoroutine (UpdateSpawnRate ());
	}

	IEnumerator DelaySpawn()
	{
		_RoutineHandle = true;
		_UpdateHandle = true;
		yield return new WaitForSeconds (10.0f);
		_RoutineHandle = false;
		_UpdateHandle = false;
	}


	IEnumerator SpawnEnemy()
	{

		if (!_RoutineHandle && _SpawnerEnabled) 
		{
			
				_RoutineHandle = true;
				Instantiate (_CurrentSpawn, this.transform.position, this.transform.rotation);
				yield return new WaitForSeconds (_DefaultSpawnRate);
				_RoutineHandle = false;

		}
	}

	IEnumerator UpdateSpawnRate()
	{
		if (!_UpdateHandle) 
		{
			_UpdateHandle = true;


			switch (_CreaturesKilled) 
			{

			case 10:
				{
					{
						_SpawnerEnabled = false;
						yield return new WaitForSeconds (30.0f);
						_SpawnerEnabled = true;
						_UpdateHandle = false;
						_DefaultSpawnRate = _SpawnRates [0];
					}
				}
				break;

			case 40:
				{
					_SpawnerEnabled = false;
					yield return new WaitForSeconds (30.0f);
					_SpawnerEnabled = true;
					_UpdateHandle = false;
					_DefaultSpawnRate = _SpawnRates [1];
				}
				break;

			case 70:
				{
					_SpawnerEnabled = false;
					yield return new WaitForSeconds (30.0f);
					_SpawnerEnabled = true;
					_UpdateHandle = false;
					_DefaultSpawnRate = _SpawnRates [2];
				}
				break;

			case 90:
				{
					_SpawnerEnabled = false;
					yield return new WaitForSeconds (30);
					_SpawnerEnabled = true;
					_UpdateHandle = false;
					_CurrentSpawn = _Soldier;
					_DefaultSpawnRate = _SpawnRates [3];
				}
				break;

			case 110:
				{
					_SpawnerEnabled = false;
					yield return new WaitForSeconds (40);
					_SpawnerEnabled = true;
					_UpdateHandle = false;
					_DefaultSpawnRate = _SpawnRates [4];
				}
				break;

			case 130:
				{
					_SpawnerEnabled = false;
					yield return new WaitForSeconds (40);
					_SpawnerEnabled = true;
					_UpdateHandle = false;
					_DefaultSpawnRate = _SpawnRates [5];
				}
				break;


			}
			_UpdateHandle = false;
		}
	}



}
