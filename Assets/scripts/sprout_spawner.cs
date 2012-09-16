using UnityEngine;
using System.Collections;

public class sprout_spawner : MonoBehaviour {
	
	public GameObject sprout;
	public GameObject side;
	
	float side_width;
	float side_length;
	
	float timer = 0f;
	float spawn_interval = 2.0f;
	
	int maxSpawnTries = 15;
	
	float bufferSize = 2.5f;
	
	static float minDistance = 7.0f;
	
	public GameObject bottom_left;
	
	// Use this for initialization
	void Start () {
		//side_width = GetComponent<MeshRenderer>().bounds.size.x;
		//side_length = GetComponent<MeshRenderer>().bounds.size.z;
		//side_width = transform.localScale.x * 2.0f;
		//side_length = transform.localScale.z * 2.0f;
		side_width = 50.0f;
		side_length = 30.0f;
		//side_width = transform.parent.GetComponent<MeshRenderer>().bounds.size.x * transform.parent.localScale.x;
		//side_length = transform.parent.GetComponent<MeshRenderer>().bounds.size.z * transform.parent.localScale.z;
		
		//side_width = GetComponent<MeshRenderer>().bounds.size.x * transform.localScale.x;
		//side_length = GetComponent<MeshRenderer>().bounds.size.z * transform.localScale.z;
		
		side_width /= 2;
		side_width -= bufferSize;
	}
	
	static bool too_close(Vector3 pos) {
		float minDist = 999.0f;
		foreach (big_flower o in GameObject.FindSceneObjectsOfType(typeof(big_flower))) {
			minDist = Mathf.Min(Vector3.Distance(pos, o.transform.localPosition), minDist);
			if (Vector3.Distance(pos, o.transform.localPosition) < minDistance) {
				//Debug.Log("Too close: " + Vector3.Distance(pos, o.transform.localPosition).ToString());
				return true;
			}
		}
		foreach (little_flower o in GameObject.FindSceneObjectsOfType(typeof(little_flower))) {
			minDist = Mathf.Min(Vector3.Distance(pos, o.transform.localPosition), minDist);
			if (Vector3.Distance(pos, o.transform.localPosition) < minDistance) {
				//Debug.Log("Too close: " + Vector3.Distance(pos, o.transform.localPosition).ToString());
				return true;
			}
		}
		foreach (onion o in GameObject.FindSceneObjectsOfType(typeof(onion))) {
			minDist = Mathf.Min(Vector3.Distance(pos, o.transform.localPosition), minDist);
			if (Vector3.Distance(pos, o.transform.localPosition) < minDistance) {
				//Debug.Log("Too close: " + Vector3.Distance(pos, o.transform.localPosition).ToString());
				return true;
			}
		}
		
		//Debug.Log("Min distance: " + minDist.ToString());
		return false;
	}
	
	void Update () {
		timer += Time.deltaTime;
		
		if(timer >= spawn_interval){
			Vector3 coords1, coords2;
			int tries = 0;
			do {
				coords1 = new Vector3(Random.Range(bufferSize + minDistance/2.0f, side_width - minDistance/2.0f), 0, Random.Range(-side_length/2.0f + minDistance/2.0f, side_length/2.0f - minDistance/2.0f));
				coords2 = new Vector3(-Random.Range(bufferSize + minDistance/2.0f, side_width - minDistance/2.0f), 0, Random.Range(-side_length/2.0f + minDistance/2.0f, side_length/2.0f - minDistance/2.0f));
				//coords = bottom_left.transform.position + new Vector3(Random.Range(minDistance/2.0f, side_width - minDistance/2.0f), 0, Random.Range(minDistance/2.0f, side_length - minDistance/2.0f));
			} while (tries++ < maxSpawnTries && (too_close(coords1) || too_close(coords2)));
			
			if (tries < maxSpawnTries) {
				GameObject inst = Instantiate(sprout) as GameObject;
				
				inst.transform.parent = transform;
				//inst.transform.rotation = transform.parent.rotation;
				//inst.transform.localRotation = Quaternion.identity;
				inst.transform.localPosition = coords1;
				inst.GetComponent<sprout>().is_top = true;
				
				inst = Instantiate(sprout) as GameObject;
				
				inst.transform.parent = transform;
				//inst.transform.rotation = transform.parent.rotation;
				//inst.transform.localRotation = Quaternion.identity;
				inst.transform.localPosition = coords2;
				inst.GetComponent<sprout>().is_top = false;
			}
			
			//Debug.Log(tries);
			
			timer -= spawn_interval;
			
		}
	
	}
}
