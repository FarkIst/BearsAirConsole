using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ExplosionDamage(gameObject.transform.position, 5f);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        int i = 0;
        while(i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    }
}
