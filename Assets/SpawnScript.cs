using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	public Transform CubePrefab;
	
	public float spawnTime = 1f;
	private float nextSpawn;

	// Use this for initialization
	void Start () {
		nextSpawn = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		nextSpawn -= Time.deltaTime;
		if (nextSpawn < 0) {
			nextSpawn = spawnTime;
			Instantiate(CubePrefab, transform.position, Quaternion.identity);
		}
	}
}
