using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class touchscript : MonoBehaviour {
	
	//keep track of score here just for funziez
	int botscore = 0;
	int topscore = 0;
	public TextAsset leaderboards;
	bool scoring_top = false;
	bool scoring_bot = false;
	int toprank = -1;
	int botrank = -1;
	
	string pname = "";
	TouchScreenKeyboard keyboard;
	
	
	public string[] lines;
	
	void OnGUI(){
		//scoring stuff	
		if(scoring_top){
			GUI.Label(new Rect(15, 15, Screen.width-15, 200), "HIGH SCORE TOP PLAYER! ENTER YOUR NAME!");
			pname = keyboard.text;
			
			if(keyboard.done){
				string[] temp = lines[toprank].Split(' ');
				temp[0] = pname;
				lines[toprank] = "";
				foreach(string tt in temp)
					lines[toprank] += tt;
				
				pname = "";
				scoring_top = false;
			}
			
			
			
		}
		else if(scoring_bot){
			GUI.Label(new Rect(15, 15, Screen.width-15, 200), "HIGH SCORE BOTTOM PLAYER! ENTER YOUR NAME!");
			pname = keyboard.text;
			
			if(keyboard.done){
				string[] temp = lines[botrank].Split(' ');
				temp[0] = pname;
				lines[botrank] = "";
				foreach(string tt in temp)
					lines[botrank] += tt;
				
				scoring_bot = false;
			}
			
		}
		
	}
	
	void Insert(int i, string s){
		for(int k = lines.Length - 1; k >= 0; k--){
			if(k > i)
				lines[k+1] = lines[k];
			else if(k == i)
				lines[k] = s;
			
		}
		
	}
	
	IEnumerator bottom_scoring(){
		while(scoring_top)
			yield return new WaitForSeconds(1f);
		
		
		keyboard = TouchScreenKeyboard.Open(pname, TouchScreenKeyboardType.Default, false);
		scoring_bot = true;
		
	}
	
	IEnumerator top_scoring(){
		while(scoring_bot)
			yield return new WaitForSeconds(1f);
		
		scoring_top = true;
		keyboard = TouchScreenKeyboard.Open(pname, TouchScreenKeyboardType.Default, false);

	}
	
	public void RecordScores(){
		
		Debug.Log ("Recording scores...");
		
		int toprank = -1;
		int botrank = -1;
		int i = 0;
		
		
		//if(lines){
		foreach(string line in lines){
			string [] fields = line.Split(' ');
			int score = int.Parse(fields[fields.Length-1]);
			if(topscore > score && toprank == -1){
				
				toprank = i;
				Insert(i, "Placeholder " + topscore);
								
				
			}
			else if(botscore > score && botrank == -1){
				botrank = i;
				Insert(i, "Placeholder " + botscore);
				StartCoroutine(bottom_scoring());
				
				
			}
			
			i++;
		}
		//}
		
		
	}
	
	// Use this for initialization
	void Start () {		
		lines = leaderboards.text.Split('\n');
	
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
						big_flower temp = hit.rigidbody.gameObject.GetComponent<big_flower>();
						if(temp.is_top)
							topscore += temp.points;
						else
							botscore += temp.points;
						/*if(hit.rigidbody.gameObject.transform.parent.name == "bottom_side")
							botscore += hit.rigidbody.gameObject.GetComponent<big_flower>().points;
						else
							topscore += hit.rigidbody.gameObject.GetComponent<big_flower>().points;
						*/
						Destroy(hit.rigidbody.gameObject);
					}
					else if(hit.rigidbody.gameObject.name.Contains("little_flower")){
						little_flower temp = hit.rigidbody.gameObject.GetComponent<little_flower>();
						if(temp.is_top)
							topscore += temp.points;
						else
							botscore += temp.points;
						/*if(hit.rigidbody.gameObject.transform.parent.name == "bottom_side")
							botscore += hit.rigidbody.gameObject.GetComponent<little_flower>().points;
						else
							topscore += hit.rigidbody.gameObject.GetComponent<little_flower>().points;
						*/
						Destroy(hit.rigidbody.gameObject);
						
						
					}
					
					Debug.Log("Registered a hit");
				}
			}
		}
	
	}
}
