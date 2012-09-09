using UnityEngine;
using System.Collections;

public class sprout_spawner : MonoBehaviour {
	
	public GameObject sprout;
	public GameObject side;
	float timer = 0f;
	float side_width;
	float side_length;
	
	public GameObject bottom_left;
	
	// Use this for initialization
	void Start () {
		side_width = GetComponent<MeshRenderer>().bounds.size.x;
		side_length = GetComponent<MeshRenderer>().bounds.size.z;
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer > 1f){
			Vector3 coords = bottom_left.transform.position + new Vector3(Random.Range(0, side_width), 0, Random.Range(0, side_length));
			//Debug.Log(coords);
			
			
			GameObject inst = Instantiate(sprout) as GameObject;
			inst.transform.parent = transform.parent;
			inst.transform.position = coords;
			
			timer = 0f;
			
			/*Vector3 coords = new Vector2(Random.Range(0, side.GetComponent<Mesh>().bounds.size.x), 0,
				Random.Range(0, side.GetComponent<Mesh>().bounds.size.z));
			GameObject inst = Instantiate(sprout, */
			
		}
	
	}
}
