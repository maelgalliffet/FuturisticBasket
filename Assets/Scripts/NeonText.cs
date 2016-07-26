using UnityEngine;
using System.Collections;

public class NeonText : MonoBehaviour {

	public Sprite[] neonLetters;
	public Sprite[] neonNumbers;
	public Sprite[] neonSymbols;
	public int score;
	public bool b_newPoint = false;
	public enum TypeText {TIME,SCORE};
	public TypeText typeText;
	private float time=0;
	// Use this for initialization
	void Start () {
		if (typeText == TypeText.SCORE) {
			Write ("Score  0");
		} else if (typeText == TypeText.TIME) {
			Write ("Time  " + time.ToString ("F1"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (typeText == TypeText.SCORE && b_newPoint) {
			RemoveText ();
			Write ("Score  " + score.ToString ());
			b_newPoint = false;
		}

		if (typeText == TypeText.TIME) {
			RemoveText ();
			Write ("Time  " + time.ToString ("F1"));
		}
	
	}

	public void Write(string a_text){
		string text = a_text.ToUpper ();
		char[] charArrayText = text.ToCharArray ();
		for (int i = 0; i < charArrayText.Length; i++) {
			if (charArrayText[i] != ' ') {
				GameObject newLetterObject = new GameObject (charArrayText [i].ToString ());
				newLetterObject.AddComponent<SpriteRenderer> ().sprite = GetSprite (charArrayText [i]);
				newLetterObject.transform.SetParent(transform);
				newLetterObject.transform.localPosition = new Vector3(0.25f * (float)i,0.0f,0.0f);
				newLetterObject.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
				newLetterObject.layer = 9; //Text layer
				newLetterObject.transform.localRotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, 0.0f));
			}
		}
	}
	public Sprite GetSprite(char letter){
		if (char.IsLetter (letter)) {
			return neonLetters [((int)letter) - 65];
		} else if (char.IsDigit (letter)) {
			return neonNumbers [(int)char.GetNumericValue (letter)];
		} else {
			return neonSymbols [10];
		}
	}
	public void RemoveText(){
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}
	}
}
