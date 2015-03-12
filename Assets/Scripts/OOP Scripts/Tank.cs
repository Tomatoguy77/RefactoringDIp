using UnityEngine;
using System.Collections;

public class Tank : DestructableObject {

	public Camera camera;
	private Transform[] transforms;
	private Transform turret;
	private Vector3 targetPos;
	private Transform nozzle;
	private float reloadTime;
	public float timeToReload;


	// Use this for initialization
	public virtual void Start () {
		reloadTime = 0;
		findNozzleTurret();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		aimTurret ();
		turret.LookAt(targetPos);
		fireBullet ();
		reloadTimer ();
	}

	protected virtual void findNozzleTurret()
	{
		bool turretFound = false;
		
		transforms = gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform t in transform)
		{
			if (t.gameObject.name == "turret")
			{
				turret = t;
				turretFound = true;
			}
			if (t.gameObject.name == "nozzle")
			{
				nozzle = t;
			}
		}

		if (!turretFound) 
		{
			print ("no turret was found in the gameObject");
		}
	}

	void aimTurret()
	{
		Vector3 mousePos = Input.mousePosition;    //(x,y,z)
		mousePos.z = camera.transform.position.y - turret.transform.position.y;
		
		Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
		
		targetPos = worldPos;
		
		base.Update();
	}

	void reloadTimer()
	{
		reloadTime += Time.deltaTime;
		if (reloadTime >= timeToReload) 
		{
			CheckForPlayer();
		}
	}

	void fireBullet()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Quaternion rotation = Quaternion.Euler(Vector3.up * turret.transform.rotation.eulerAngles.y);
			
			Instantiate(bulletPrefab, nozzle.transform.position, turret.transform.rotation);
		}
	}
}
