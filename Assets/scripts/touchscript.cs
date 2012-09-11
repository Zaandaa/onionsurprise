using UnityEngine;
using System.Collections;

public class touchscript : MonoBehaviour {
	
	//keep track of score here just for funziez
	int botscore = 0;
	int topscore = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		for(int i = 0; i < Input.touchCount; i++){
			if (Input.GetTouch(i).phase.ToString().Equals("Began")) {
				RaycastHit hit = new RaycastHit();
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 0f));
				if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
					
					//miss any rigidbody
					if (!hit.rigidbody) {
						continue;
					}
					
					if(hit.rigidbody.gameObject.name.Contains("big_flower")){
						if(hit.rigidbody.gameObject.transform.parent.name == "bottom_side")
							botscore += hit.rigidbody.gameObject.GetComponent<big_flower>().points;
						else
							topscore += hit.rigidbody.gameObject.GetComponent<big_flower>().points;
						
						Destroy(hit.rigidbody.gameObject);
					}
					else if(hit.rigidbody.gameObject.name.Contains("little_flower")){
						if(hit.rigidbody.gameObject.transform.parent.name == "bottom_side")
							botscore += hit.rigidbody.gameObject.GetComponent<little_flower>().points;
						else
							topscore += hit.rigidbody.gameObject.GetComponent<little_flower>().points;
						
						Destroy(hit.rigidbody.gameObject);
						
						
					}
					
					Debug.Log("Registered a hit");
				}
			}
		}
	
	}
}
