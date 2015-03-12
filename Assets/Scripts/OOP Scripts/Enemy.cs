using UnityEngine;
using System.Collections;

public class Enemy : Tank {
	private float reloadTime;
	public float timeToReload;
	public GameObject bulletPrefab;
	public float shootingRange;
	private Transform turret;
	private Transform nozzle;

	// Use this for initialization
	void Start () {
		Transform[] transforms = this.gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform t in transforms) 
		{
			if(t.gameObject.name == "turret")
			{
				turret = t;
				
			}
			if(t.gameObject.name == "nozzle")
			{
				nozzle = t;
				
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		DetermineTarget ();
		CheckIfSeesPlayer ();
	}

	void DetermineTarget()
	{
		Ray myRay = new Ray();
		myRay.origin = turret.position;
		myRay.direction = turret.forward;
		
		RaycastHit hitInfo;
	}

	void CheckIfSeesPlayer()
	{
		if(Physics.Raycast(myRay, out hitInfo, shootingRange))
		{
			print(hitInfo.collider.gameObject.name);
			string hitObjectName = hitInfo.collider.gameObject.name;
			
			if(hitObjectName == "Tank")
			{
				//zo ja shieten op tank
				Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);
				
				//zo je schieten en reload time weer op 0 zetten
				reloadTime = 0f;
			}
		}
	}
}
