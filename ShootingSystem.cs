using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingSystem : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform gunholder;
    public float fireRate = 1f;
    public float bulletSpeed = 50.0f;
    public int rayCastLength = 100;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource gunAudio;
    private float nextFire;
    private RaycastHit shootHit;

    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out shootHit, rayCastLength))
        {
            string tagName = shootHit.collider.gameObject.tag;

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                StartCoroutine(ShotEffect());

                GameObject go = Instantiate(bulletPrefab, gunholder.position, gunholder.rotation) as GameObject;
                go.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        yield return shotDuration;
    }
}
