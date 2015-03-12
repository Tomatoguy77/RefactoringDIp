using UnityEngine;
using System.Collections;

public class Player : Tank {
    Rigidbody rb;
    public float rotationSpeed = 0f;
	public float moveSpeed = 0f;
    public Camera camera;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();

	
	}
	
	// Update is called once per frame
	override void Update () {
        undoVelocity();
        playerMovement();
        determineWorldPos();
	}
    void determineWorldPos() {

        Vector3 mousePos = Input.mousePosition;    //(x,y,z)
        mousePos.z = camera.transform.position.y - turret.transform.position.y;

        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);

        targetPos = worldPos;

        base.Update();
    
    }
    void undoVelocity() {
        if (rb.velocity != Vector3.zero)//(0,0,0)
        {
            rb.velocity = Vector3.zero;
        }
        if (rb.angularVelocity != Vector3.zero)
        {
            rb.angularVelocity = Vector3.zero;
        }
    
    }
    void playerMovement()   {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed);
        }

    }
}
