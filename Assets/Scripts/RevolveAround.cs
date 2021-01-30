using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveAround : MonoBehaviour
{
    public GameObject target;

    public float radius;
    public float age = 0;
    public float timeChange = 1;

    float num1;
    float num2;

    private void Start()
    {

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

        timeChange = PauseScript.sliderControl;

    }
}
