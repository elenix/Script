using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorMove : MonoBehaviour {

    public float speedToPlayer;
    public int currentHealth = 1;
    public GameObject explosion;

    private Transform Player;
    private Rigidbody rb;
    AudioSource explodeMusic;
    AudioClip explodeClip;

    void Start ()
    {
        explodeMusic = GetComponent<AudioSource>();
        explodeClip = explodeMusic.clip;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speedToPlayer * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            currentHealth -= 1;
        }

        if (currentHealth <= 0)
        {
            explodeMusic.PlayOneShot(explodeClip);
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            Destroy(gameObject, explodeClip.length);
            Destroy(expl, 1); // delete the explosion after 3 seconds
        }
    }
}
