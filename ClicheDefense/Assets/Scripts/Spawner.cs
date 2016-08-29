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

	private bool _SpawnerEnabled = false;
	public int _CreaturesKilled = 0;

	[SerializeField] public List<float> _SpawnRates;
	[SerializeField] private GameObject _CaveMan;
	[SerializeField] private GameObject _Soldier;
	[SerializeField] private GameObject _HorseyKnight;

	[SerializeField] private GameObject _StartWaveUI;
	[SerializeField] private GameObject _WinScreen;

	private GameObject _CurrentSpawn;

	void Start () 
	{
		_CurrentSpawn = _CaveMan;

		StartCoroutine (SpawnEnemy());
		StartCoroutine (UpdateSpawnRate ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}




	IEnumerator SpawnEnemy()
	{
		if (_SpawnerEnabled) 
		{
			Instantiate (_CurrentSpawn, this.transform.position, this.transform.rotation);
			yield return new WaitForSeconds (_DefaultSpawnRate);
			StartCoroutine (SpawnEnemy ());
		} 

		else 
		{
			yield return new WaitForSeconds (1.0f);
			StartCoroutine (SpawnEnemy ());
		}
			


	}

	public void EnableSpawner()
	{
		_SpawnerEnabled = true;
		_StartWaveUI.gameObject.SetActive (false);
	}

	IEnumerator UpdateSpawnRate()
	{

			switch (_CreaturesKilled) 
			{

			case 10:
				{
					{
						_SpawnerEnabled = false;
						_DefaultSpawnRate = _SpawnRates [0];
						_StartWaveUI.gameObject.SetActive (true);
						_CreaturesKilled += 1;
					}
				}
				break;

			case 40:
				{
					_SpawnerEnabled = false;
					_DefaultSpawnRate = _SpawnRates [1];
					_StartWaveUI.gameObject.SetActive (true);
					_CreaturesKilled += 1;
				}
				break;

			case 70:
				{
					_SpawnerEnabled = false;
					_DefaultSpawnRate = _SpawnRates [2];
					_StartWaveUI.gameObject.SetActive (true);
					_CreaturesKilled += 1;
				}
				break;

			case 90:
				{
					_SpawnerEnabled = false;
					_CurrentSpawn = _Soldier;
					_DefaultSpawnRate = _SpawnRates [3];
					_StartWaveUI.gameObject.SetActive (true);
					_CreaturesKilled += 1;
				}
				break;

			case 110:
				{
					_SpawnerEnabled = false;
					_DefaultSpawnRate = _SpawnRates [4];
					_StartWaveUI.gameObject.SetActive (true);
					_CreaturesKilled += 1;
				}
				break;

			case 130:
				{
					_SpawnerEnabled = false;
					_DefaultSpawnRate = _SpawnRates [5];
					_StartWaveUI.gameObject.SetActive (true);
					_CreaturesKilled += 1;
				}
				break;

			case 170:
				{
					_SpawnerEnabled = false;
					_DefaultSpawnRate = _SpawnRates [6];
					_StartWaveUI.gameObject.SetActive (true);
					_CreaturesKilled += 1;
				}
				break;

			case 210:
				{
					_SpawnerEnabled = false;
					_CurrentSpawn = _HorseyKnight;
					_DefaultSpawnRate = _SpawnRates [7];
					_StartWaveUI.gameObject.SetActive (true);
					_CreaturesKilled += 1;
				}
				break;

			case 230:
				{
					_SpawnerEnabled = false;
					_DefaultSpawnRate = _SpawnRates [8];
					_StartWaveUI.gameObject.SetActive (true);
					_CreaturesKilled += 1;
				}
				break;

			case 260:
				{
					_SpawnerEnabled = false;
					_DefaultSpawnRate = _SpawnRates [9];
					_StartWaveUI.gameObject.SetActive (true);
					_CreaturesKilled += 1;
				}
				break;

			case 300:
				{
					_SpawnerEnabled = false;
					_WinScreen.SetActive (true);
					_StartWaveUI.gameObject.SetActive (false);
					_CreaturesKilled += 1;
				}
				break;


		}

		yield return new WaitForSeconds (.10f);
		StartCoroutine (UpdateSpawnRate ());
	}



}
