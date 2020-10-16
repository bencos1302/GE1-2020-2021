using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 30;
    public float bulletForce = 3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision c)
    {
        Destroy(this.gameObject, 0);

        // Add force from collision
        Vector3 dir = c.contacts[0].point - transform.position;
        dir = -dir.normalized;
        c.gameObject.GetComponent<Rigidbody>().AddForce(dir*bulletForce);
    }
}
