using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPlanet : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool moveIt = false;
    public static GameObject planetClicked;

    public GameObject camMount;
    private Vector3 relPos;
    public GameObject MainCam;
    public GameObject start;

    public GameObject sun;

    private GameObject privateGO;

    private float smoothTime = 1f;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        MainCam = GameObject.Find("Main Camera");
        sun = GameObject.Find("Sun");
        start = GameObject.Find("StartSpot");
        planetClicked = null;
    }

    void Update()
    {
        float zoomChange = PauseScript.sliderControl;
        float largeNum = zoomChange * 50;

        if (PauseScript.sliderControl >= 2 || PauseScript.sliderControl <= -2)
        {
            smoothTime = zoomChange / largeNum;
        }
        else if (PauseScript.sliderControl == 0)
        {
            smoothTime = 1;
        }
        else
        {
            smoothTime = .3f;
        }

        if (moveIt && planetClicked.name == gameObject.name)
        {
            privateGO = camMount;
            relPos = RotateCamera(planetClicked.transform.position, MainCam.transform.position);
            Quaternion rotation = Quaternion.LookRotation(relPos, Vector3.up);
            MainCam.transform.rotation = rotation;
            MainCam.transform.position = Vector3.SmoothDamp(MainCam.transform.position, privateGO.transform.position, ref velocity, smoothTime);
            //MainCam.transform.position = Vector3.MoveTowards(MainCam.transform.position, privateGO.transform.position, step);
        }
        if (!moveIt)
        {
            privateGO = start;
            relPos = RotateCamera(sun.transform.position, MainCam.transform.position);
            Quaternion rotation = Quaternion.LookRotation(relPos, Vector3.up);
            MainCam.transform.rotation = rotation;
            MainCam.transform.position = Vector3.SmoothDamp(MainCam.transform.position, privateGO.transform.position, ref velocity, smoothTime);
            //MainCam.transform.position = Vector3.MoveTowards(MainCam.transform.position, privateGO.transform.position, step);
        }

        
    }

    private void OnMouseDown()
    {
        if (!moveIt)
        {
            //print("clicked " + gameObject.name);
            planetClicked = GameObject.Find(gameObject.name);
            moveIt = true;
        }
        
    }

    public Vector3 RotateCamera(Vector3 lookAt, Vector3 cam)
    {
        Vector3 relPosition = lookAt - cam;

        return relPosition;
    }

    public void backFunction()
    {
        moveIt = false;
        planetClicked = null;
    }
}
