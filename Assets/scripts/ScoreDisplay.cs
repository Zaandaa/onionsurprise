using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {
	touchscript ts;
	TextMesh tm;
	
	public bool isTop;
	
	void Start () {
		ts = FindObjectOfType(typeof(touchscript)) as touchscript;
		tm = GetComponent<TextMesh>();
	}
	
	void Update () {
		int score;
		if (isTop) {
			score = ts.topscore;
		} else {
			score = ts.botscore;
		}
		tm.text = score.ToString().PadLeft(2, '0');
	}
}
