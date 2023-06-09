using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fireball : GameBehaviour
{
    public Vector3 target;
    public ParticleSystem explosion;
    public GameObject explosionOB;

    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 50 * Time.deltaTime);
        //Vector3 position = _SM.fireball.speed
        //body.MovePosition(position);

        gameObject.transform.position = Vector3.MoveTowards(body.position, target, 1*Time.deltaTime); 
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Land"))
        {
            //explode

            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;

            gameObject.GetComponent<Renderer>().enabled = false;

            explosion = explosionOB.GetComponentInChildren<ParticleSystem>(true);
            explosion.Play(true);

            Destroy(gameObject, 3);
        }
    }
}
