using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Collider glassCollider1;
	private Collider glassCollider2;
	private Collider batCollider1;
	private Collider batCollider2;
	private Renderer renderer;
	private BallLauncher ballLauncher;
	public Transform explosionPrefab;
	public Transform bouncePrefab;
	public Transform pointPrefab;
	public AudioClip explosionClip;
	public AudioClip bounceClip;
	public AudioClip pointClip;
	private bool m_Exploded = false;
	private NeonText neonText;
	private int nbBounces = 0;
	public int maxBounces;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		GameObject glass1 = GameObject.Find ("GlassBall1");
		GameObject glass2 = GameObject.Find ("GlassBall2");
		GameObject bat = GameObject.Find ("bat");
		batCollider1 = bat.GetComponentsInChildren<BoxCollider> ()[0];
		batCollider2 = bat.GetComponentsInChildren<BoxCollider> ()[1];
		glassCollider1 = glass1.GetComponent<MeshCollider> ();
		glassCollider2 = glass2.GetComponent<MeshCollider> ();
		ballLauncher = GameObject.Find ("Ball Launcher").GetComponent<BallLauncher> ();
		neonText =  GameObject.Find ("NeonScoreText").GetComponent<NeonText> ();
		audioSource = GetComponent<AudioSource> ();
		renderer = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (enabled)
		{
			if (col.contacts.Length > 0)
			{
				nbBounces++;
				if (col.collider == glassCollider1 || col.collider == glassCollider2) {
					Instantiate (pointPrefab, col.contacts [0].point,
						Quaternion.LookRotation (col.contacts [0].normal));
					ballLauncher.nbBalls--;
					neonText.score++;
					neonText.b_newPoint = true;
					PlayPointSound ();
					renderer.enabled = false;
					Destroy (this.gameObject,pointClip.length);

				}
				else if (col.collider == batCollider1 || col.collider == batCollider2) {
					nbBounces = 0;
				}
				else if (nbBounces >= maxBounces) {
					if (!m_Exploded) {
						Instantiate (explosionPrefab, col.contacts [0].point,
							Quaternion.LookRotation (col.contacts [0].normal));
						ballLauncher.nbBalls--;
						m_Exploded = true;
						PlayExplosionSound ();
						renderer.enabled = false;
						Destroy (this.gameObject,explosionClip.length);
					}
				} else {
					Instantiate (bouncePrefab, col.contacts [0].point, Quaternion.LookRotation (col.contacts [0].normal));
					PlayBounceSound ();
				}
			}
		}
	}

	private void PlayExplosionSound()
	{
		audioSource.clip = explosionClip;
		audioSource.Play ();
	}
	private void PlayBounceSound()
	{
		audioSource.clip = bounceClip;
		audioSource.Play ();
	}
	private void PlayPointSound()
	{
		audioSource.clip = pointClip;
		audioSource.Play ();
	}
}
