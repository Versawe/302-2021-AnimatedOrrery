using JetBrains.Annotations;
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

    Vector3 offset;

    public LineRenderer line;
    private int vertex = 45;
    public float lineRadius;

    public List<string> grabEm;
    public string data;


    private void Start()
    {
        target = GameObject.Find("Sun");
        num1 = UnityEngine.Random.Range(0, 20);
        num2 = UnityEngine.Random.Range(0, 20);
        grabEm = AnimMath.ExtractOffset(num1, num2);

        data = getCorrectData();
        StartCoroutine(GeneratePoints());
    }

    void Update()
    {
        lineRadius = Vector3.Distance(transform.position, target.transform.position);

        age += timeChange * Time.deltaTime;

        offset = AnimMath.RandomRotation(radius, age, num1, num2);

        transform.position = target.transform.position + offset;

        if (num1 <= 0) num1 = 0;
        if (num1 >= 20) num1 = 20;

        if (num2 <= 0) num2 = 0;
        if (num2 >= 20) num2 = 20;

        timeChange = PauseScript.sliderControl;


        line.transform.position = target.transform.position;

    }

    
    private IEnumerator GeneratePoints()
    {

        line = GetComponentInChildren<LineRenderer>();

        //generate points
        float rad = 0;

        Vector3[] pts = new Vector3[vertex];

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < vertex; i++)
        {
            if (data == "ssc")
            {
                pts[i] = new Vector3(Mathf.Sin(rad), Mathf.Sin(rad), Mathf.Cos(rad)) * lineRadius;
                rad += Mathf.PI * 2 / vertex; // increases the angle
            }
            else if (data == "ccs")
            {
                pts[i] = new Vector3(Mathf.Cos(rad), Mathf.Cos(rad), Mathf.Sin(rad)) * lineRadius;
                rad += Mathf.PI * 2 / vertex; // increases the angle
            }
            else if (data == "css")
            {
                pts[i] = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), Mathf.Sin(rad)) * lineRadius;
                rad += Mathf.PI * 2 / vertex; // increases the angle
            }
            else if (data == "scc")
            {
                pts[i] = new Vector3(Mathf.Sin(rad), Mathf.Cos(rad), Mathf.Cos(rad)) * lineRadius;
                rad += Mathf.PI * 2 / vertex; // increases the angle
            }
            else if (data == "csc")
            {
                pts[i] = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), Mathf.Cos(rad)) * lineRadius;
                rad += Mathf.PI * 2 / vertex; // increases the angle
            }
            else if (data == "csy")
            {
                pts[i] = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * lineRadius;
                rad += Mathf.PI * 2 / vertex; // increases the angle
            }
            else if (data == "scy")
            {
                pts[i] = new Vector3(Mathf.Sin(rad), Mathf.Cos(rad), 0) * lineRadius;
                rad += Mathf.PI * 2 / vertex; // increases the angle
            }
            else if (data == "scz")
            {
                pts[i] = new Vector3(Mathf.Sin(rad), 0, Mathf.Cos(rad)) * lineRadius;
                rad += Mathf.PI * 2 / vertex; // increases the angle
            }
            else if (data == "csz")
            {
                pts[i] = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * lineRadius;
                rad += Mathf.PI * 2 / vertex; // increases the angle
            }
        }
        line.positionCount = vertex;
        line.SetPositions(pts);
    }

    private string getCorrectData()
    {
        string dat = "";
        if (grabEm.Count == 3)
        {
            if (grabEm[0] == "Mathf.Sin" && grabEm[1] == "Mathf.Sin" && grabEm[2] == "Mathf.Cos")
            {
                dat = "ssc";
            }
            if (grabEm[0] == "Mathf.Cos" && grabEm[1] == "Mathf.Cos" && grabEm[2] == "Mathf.Sin")
            {
                dat = "ccs";
            }
            if (grabEm[0] == "Mathf.Cos" && grabEm[1] == "Mathf.Sin" && grabEm[2] == "Mathf.Sin")
            {
                dat = "css";
            }
            if (grabEm[0] == "Mathf.Sin" && grabEm[1] == "Mathf.Cos" && grabEm[2] == "Mathf.Cos")
            {
                dat = "scc";
            }
            if (grabEm[0] == "Mathf.Cos" && grabEm[1] == "Mathf.Sin" && grabEm[2] == "Mathf.Cos")
            {
                dat = "csc";
            }
        }
        if (grabEm.Count == 2)
        {
            if (grabEm[0] == "Mathf.Cos x" && grabEm[1] == "Mathf.Sin y")
            {
                dat = "csy";
            }
            if (grabEm[0] == "Mathf.Sin x" && grabEm[1] == "Mathf.Cos y")
            {
                dat = "scy";
            }
            if (grabEm[0] == "Mathf.Cos x" && grabEm[1] == "Mathf.Sin z")
            {
                dat = "csz";
            }
            if (grabEm[0] == "Mathf.Sin x" && grabEm[1] == "Mathf.Cos z")
            {
                dat = "scz";
            }

        }

        return dat;
    }
}
