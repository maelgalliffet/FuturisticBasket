using UnityEngine;
using System.Collections;

public class TimeText : MonoBehaviour {
	public float time = 0.0f;
	// Use this for initialization
	void Start () {
		GetComponent<TextMesh> ().text = "Time : " + time.ToString("F1");
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		GetComponent<TextMesh> ().text = "Time : " + time.ToString("F1");
	}
}
