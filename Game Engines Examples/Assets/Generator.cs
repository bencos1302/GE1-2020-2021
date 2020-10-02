using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int rings = 1;
    public GameObject ringPrefab;

    public float radius = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < rings; j++)
        {
            // Calculate how many fit in the cirumference of the circle
            float circumference = Mathf.PI * 2.0f * radius;
            float elements = (int)circumference;

            float theta = Mathf.PI * 2.0f / (float)elements;
            for (int i = 0; i < elements; i++)
            {
                GameObject hex = GameObject.Instantiate<GameObject>(ringPrefab);
                Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
                hex.transform.position = transform.TransformPoint(pos);
                hex.GetComponent<Renderer>().material.color = Color.HSVToRGB((float) j / rings, 1, 1);
                hex.transform.parent = this.transform;
            }
            radius += 1.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
