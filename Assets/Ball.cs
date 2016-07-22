using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Collider glassCollider;
	private BallLauncher ballLauncher;
	private ScoreText scoreText;
	// Use this for initialization
	void Start () {
		GameObject glass = GameObject.Find ("GlassBall");
		glassCollider = glass.GetComponent<MeshCollider> ();
		ballLauncher = GameObject.Find ("Ball Launcher").GetComponent<BallLauncher> ();
		scoreText =  GameObject.Find ("ScoreText").GetComponent<ScoreText> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if (collision.collider == glassCollider) {
			ballLauncher.nbBalls--;
			scoreText.score++;
			scoreText.b_newPoint = true;
			Destroy (gameObject);

		}
	}
}
