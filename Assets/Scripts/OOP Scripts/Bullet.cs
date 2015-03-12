using UnityEngine;
using System.Collections;

public class Bullet : TempObject {
	public GameObject bulletPrefab;
	private GameObject turret;
	private GameObject nozzle;
	public float speed;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveBullet ();
	}

	void OnCollisionEnter(Collision coll)
	{
		removeOnImpact ();
	}

	void moveBullet()
	{
		float delta = Time.deltaTime;
		transform.Translate(Vector3.forward * speed * delta);
	}

	void removeOnImpact()
	{
		Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
		
		Destroy(this.gameObject);
	}
}
