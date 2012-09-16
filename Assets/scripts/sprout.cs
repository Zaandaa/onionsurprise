using UnityEngine;
using System.Collections;

public class sprout : MonoBehaviour {
	
	public GameObject big;
	public GameObject little;
	
	public bool is_top;
	
	float timer = 0f;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer > .5f){
			GameObject flower;
			if(Random.Range(0, 100) < 70) {
				flower = Instantiate(little) as GameObject;
				flower.GetComponent<little_flower>().is_top = is_top;
			} else {
				flower = Instantiate(big) as GameObject;
				flower.GetComponent<big_flower>().is_top = is_top;
			}
			flower.transform.parent = transform.parent;
			flower.transform.position = transform.position;
			
			Destroy(gameObject);
			
		}
	
	}
}
