using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLimit : MonoBehaviour {

    public float lifeTimeInSec = 2.0f;
    public GameObject explosion;

    void Awake()
    {
        Destroy(gameObject, lifeTimeInSec);
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        Destroy(expl, 0.5f); // delete the explosion after 3 seconds
    }
}
