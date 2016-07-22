using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {

	public GameObject glassBall;
	public int score = 0;
	public bool b_newPoint = false;
	// Use this for initialization
	void Start () {
		GetComponent<TextMesh> ().text = "Score : " + score;
	}
	
	// Update is called once per frame
	void Update () {
		if (b_newPoint) {
			GetComponent<TextMesh> ().text = "Score : " + score;
			b_newPoint = false;
		}
	}
}
