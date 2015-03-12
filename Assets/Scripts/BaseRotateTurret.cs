using UnityEngine;
using System.Collections;

public class BaseRotateTurret : MonoBehaviour {

	private Transform[] transforms;//naar baseclass
	protected Transform turret;//naar baseclass
	protected Vector3 targetPos;
	protected Transform nozzle;
	// Use this for initialization
	protected virtual void Start () {
		//naar baseclass

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
	
	// Update is called once per frame
	protected virtual void Update () {
		//naar baseclass
		turret.LookAt(targetPos);
	
	}
}
