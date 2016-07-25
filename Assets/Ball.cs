using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Collider glassCollider1;
	private Collider glassCollider2;
	private BallLauncher ballLauncher;
	private ScoreText scoreText;
	private int nbBounces = 0;
	public int maxBounces;
	// Use this for initialization
	void Start () {
		GameObject glass1 = GameObject.Find ("GlassBall1");
		GameObject glass2 = GameObject.Find ("GlassBall2");
		glassCollider1 = glass1.GetComponent<MeshCollider> ();
		glassCollider2 = glass2.GetComponent<MeshCollider> ();
		ballLauncher = GameObject.Find ("Ball Launcher").GetComponent<BallLauncher> ();
		scoreText =  GameObject.Find ("ScoreText").GetComponent<ScoreText> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		nbBounces++;
		if (collision.collider == glassCollider1 || collision.collider == glassCollider2) {
			ballLauncher.nbBalls--;
			scoreText.score++;
			scoreText.b_newPoint = true;
			Destroy (gameObject);

		}
		if (nbBounces == maxBounces) {
			ballLauncher.nbBalls--;
			Destroy (gameObject);
		}
	}
}
