using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveAround : MonoBehaviour
{

    public GameObject target;

    public float radius;
    public float age = 0;
    public float timeChange = 1;

    public float num1;
    public float num2;

    MeshRenderer mr;
    SphereCollider sc;

    private void Start()
    {
        target = GameObject.Find("Sun");
        radius = UnityEngine.Random.Range(2.5f,15);

        mr = GetComponent<MeshRenderer>();
        sc = GetComponent<SphereCollider>();
        gameObject.GetComponent<SpawnParticles>().enabled = false;

        num1 = UnityEngine.Random.Range(0, 20);
        num2 = UnityEngine.Random.Range(0, 20);
    }

    void Update()
    {
        age += timeChange * Time.deltaTime;

        Vector3 offset = AnimMath.RandomRotation(radius, age, num1, num2);

        transform.position = target.transform.position + offset;

        if (num1 <= 0) num1 = 0;
        if (num1 >= 20) num1 = 20;

        if (num2 <= 0) num2 = 0;
        if (num2 >= 20) num2 = 20;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            mr.enabled = false;
            gameObject.GetComponent<SpawnParticles>().enabled = true;
            sc.enabled = false;
        }
    }
}
