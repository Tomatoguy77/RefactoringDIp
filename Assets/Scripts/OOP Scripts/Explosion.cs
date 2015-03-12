using UnityEngine;
using System.Collections;

public class Explosion : TempObject {
    public float maxLifeTime;
    private float lifeTime;
    public float lightFade;
    private Light light;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();

	}
	
	// Update is called once per frame
	void Update () {
        FadeExplosion();
	}
    void FadeExplosion() {
        light.intensity -= lightFade;


        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            Destroy(this.gameObject);
        }
	
    }
}
