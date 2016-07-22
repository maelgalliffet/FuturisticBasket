using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {

	public GameObject ball;
	public float speed;
	private float time = 0.0f;
	public float ballSpawnTime = 1.0f;
	private GameObject ballsObject;
	public enum Direction {Zp,Zn,Xp,Xn};
	public Direction launcherDirection;
	private float ballWidth;
	public int maxBalls;
	public int nbBalls = 0;
	// Use this for initialization
	void Start () {
		ballsObject = new GameObject ("Balls");
		ballsObject.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= ballSpawnTime && nbBalls < maxBalls) {
			GameObject newBall = Instantiate (ball);
			newBall.transform.SetParent (ballsObject.transform);
			newBall.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			ballWidth = newBall.GetComponent<Collider> ().bounds.size.z;
			Vector3 v3_ballForce = BallForceV3 ();
			newBall.transform.localPosition = BallPosV3 ();
			newBall.GetComponent<Rigidbody> ().AddForce (v3_ballForce);
			time = 0.0f;
			nbBalls++;
		}
		
	}

	public Vector3 RandomV3(Vector3 min, Vector3 max){
		return new Vector3 (Random.Range (min.x, max.x), Random.Range (min.y, max.y), Random.Range (min.z, max.z));
	}

	public Vector3 BallForceV3(){
		Vector3 v3_min = Vector3.zero;
		Vector3 v3_max = Vector3.zero;
		if (launcherDirection == Direction.Zp) {
			v3_min.x = -1.0f;
			v3_max.x = 1.0f;
			v3_max.z = 1.0f;
		} else if (launcherDirection == Direction.Zn) {
			v3_min.x = -1.0f;
			v3_min.z = -1.0f;
			v3_max.x = 1.0f;
		} else if (launcherDirection == Direction.Xp) {
			v3_min.z = -1.0f;
			v3_max.x = 1.0f;
			v3_max.z = 1.0f;
		} else if (launcherDirection == Direction.Xn) {
			v3_min.x = -1.0f;
			v3_min.z = -1.0f;
			v3_max.z = 1.0f;
		}
		return RandomV3 (speed * v3_min, speed * v3_max);
	}

	public Vector3 BallPosV3(){
		Vector3 v3_out = Vector3.zero;
		if (launcherDirection == Direction.Zp) {
			v3_out.z += ballWidth;
		} else if (launcherDirection == Direction.Zn) {
			v3_out.z -= ballWidth;
		} else if (launcherDirection == Direction.Xp) {
			v3_out.x += ballWidth;
		} else if (launcherDirection == Direction.Xn) {
			v3_out.x -= ballWidth;
		}
		return v3_out;
	}
}
