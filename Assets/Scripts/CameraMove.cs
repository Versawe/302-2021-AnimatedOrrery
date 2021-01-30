using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public List<GameObject> planets;
    public GameObject start;
    public GameObject sun;
    //public GameObject physicalCam;
    Vector3 relPos;
    Quaternion rotation;

    private float ease = 0.01f;

    float pitch = 0;
    float targetPitch = 0;

    float pitch2 = 0;
    float targetPitch2 = 0;

    float dis = 10;
    float targetDis = 10;

    private string currPlanet = "None";
    // Start is called before the first frame update
    void Start()
    {
        currPlanet = "None";
    }

    // Update is called once per frame
    void Update()
    {
        if (currPlanet == "None")
        {
            relPos = RotateCamera(sun.transform.position, transform.position, gameObject);
            transform.position = AnimMath.Slide(transform.position, start.transform.position, ease);
        }
        if (currPlanet == "p1")
        {
            float newEase = adjustCamEase(transform.position, planets[0].GetComponent<PlanetMount>().camMount.position, ease);
            relPos = RotateCamera(planets[0].transform.position, transform.position, gameObject);
            transform.position = AnimMath.Slide(transform.position, planets[0].GetComponent<PlanetMount>().camMount.position, newEase);

        }
        if (currPlanet == "p2")
        {
            float newEase = adjustCamEase(transform.position, planets[0].GetComponent<PlanetMount>().camMount.position, ease);
            relPos = RotateCamera(planets[1].transform.position, transform.position, gameObject);
            transform.position = AnimMath.Slide(transform.position, planets[1].GetComponent<PlanetMount>().camMount.position, newEase);
        }
        if (currPlanet == "p3")
        {
            float newEase = adjustCamEase(transform.position, planets[0].GetComponent<PlanetMount>().camMount.position, ease);
            relPos = RotateCamera(planets[2].transform.position, transform.position, gameObject);
            transform.position = AnimMath.Slide(transform.position, planets[2].GetComponent<PlanetMount>().camMount.position, newEase);
        }
        if (currPlanet == "p4")
        {
            float newEase = adjustCamEase(transform.position, planets[0].GetComponent<PlanetMount>().camMount.position, ease);
            relPos = RotateCamera(planets[3].transform.position, transform.position, gameObject);
            transform.position = AnimMath.Slide(transform.position, planets[3].GetComponent<PlanetMount>().camMount.position, newEase);
        }
        if (currPlanet == "p5")
        {
            float newEase = adjustCamEase(transform.position, planets[0].GetComponent<PlanetMount>().camMount.position, ease);
            relPos = RotateCamera(planets[4].transform.position, transform.position, gameObject);
            //transform.position = AnimMath.Slide(transform.position, planets[4].GetComponent<PlanetMount>().camMount.position, ease);
            transform.position = AnimMath.Slide(transform.position, planets[4].GetComponent<PlanetMount>().camMount.position, newEase);
        }
    }

    public void Move2Planet1()
    {
        if(currPlanet == "None") currPlanet = "p1";
    }
    public void Move2Planet2()
    {
        if (currPlanet == "None") currPlanet = "p2";
    }
    public void Move2Planet3()
    {
        if (currPlanet == "None") currPlanet = "p3";
    }
    public void Move2Planet4()
    {
        if (currPlanet == "None") currPlanet = "p4";
    }
    public void Move2Planet5()
    {
        if (currPlanet == "None") currPlanet = "p5";
    }
    public void MoveBack()
    {
        if (currPlanet != "None") currPlanet = "None";
    }
    public Vector3 RotateCamera(Vector3 lookAt, Vector3 cam, GameObject camGO)
    {
        Vector3 relPosition = lookAt - cam;
        rotation = Quaternion.LookRotation(relPos, Vector3.up);
        camGO.transform.rotation = rotation;

        return relPosition;
    }

    private float adjustCamEase(Vector3 camDis, Vector3 planetDis, float easeSpeed)
    {
        float disFromEach = Vector3.Distance(camDis, planetDis);
        easeSpeed = easeSpeed / disFromEach;            
        return easeSpeed;
    }

}
