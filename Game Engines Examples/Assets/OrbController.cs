using UnityEngine;

public class OrbController : MonoBehaviour
{
    public float smoothTime = 10.0f;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "MainCamera")
        {
            Debug.Log("Collided with camera.");
            FPSController fpsCon = c.gameObject.GetComponent<FPSController>();
            TankController tankCon = this.gameObject.GetComponentInParent<TankController>();
            AITank aiCon = this.gameObject.GetComponentInParent<AITank>();
            RotateMe rotMe = this.gameObject.GetComponent<RotateMe>();
            
            fpsCon.enabled = false;
            tankCon.enabled = true;
            aiCon.enabled = false;
            rotMe.enabled = false;
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "MainCamera")
        {
            var from = c.transform;
            var to = transform.parent;

            c.transform.position = Vector3.Lerp(c.transform.position, transform.position, smoothTime * Time.deltaTime);
            c.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, smoothTime * Time.deltaTime);
        }

        if (Input.GetKey("space"))
        {
            FPSController fpsCon = c.gameObject.GetComponent<FPSController>();
            TankController tankCon = this.gameObject.GetComponentInParent<TankController>();
            AITank aiCon = this.gameObject.GetComponentInParent<AITank>();
            RotateMe rotMe = this.gameObject.GetComponent<RotateMe>();
            
            fpsCon.enabled = true;
            tankCon.enabled = false;
            aiCon.enabled = true;
            rotMe.enabled = true;
        }
    }
}
