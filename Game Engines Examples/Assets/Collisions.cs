using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public int collisionIntensity = 100;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "bullet" || c.gameObject.name == "bullet(Clone)")
        {
            Die();
        }
    }

    System.Collections.IEnumerator Fall()
    {
        yield return new WaitForSeconds(4); 
        // Make the tank fall through the floor
        gameObject.GetComponent<Collider>().enabled = !gameObject.GetComponent<Collider>().enabled;
        gameObject.GetComponent<Rigidbody>().drag = 1.0f;
    }

    void Die()
    {
        // Destroy the tank after 7 seconds
        Destroy(this.gameObject, 7);

        // Make the barrel fall off
        GameObject turret = gameObject.transform.GetChild(0).gameObject;
        if(turret.GetComponent<Rigidbody>() == null)
        {
            Rigidbody turretRB = turret.AddComponent<Rigidbody>();
            turretRB.useGravity = true;
            turretRB.isKinematic = false;
        }
        StartCoroutine(Fall());
    }
}
