using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPlanet : MonoBehaviour
{
    // Start is called before the first frame update
    private bool moveIt = false;

    public GameObject camMount;
    private Vector3 relPos;
    public GameObject MainCam;

    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        MainCam = GameObject.Find("Main Camera");
    }

    void Update()
    {
        if (moveIt)
        {
            relPos = RotateCamera(MainCam.transform.position);
            //Vector3 camMount = MoveCamera();

            Quaternion rotation = Quaternion.LookRotation(relPos, Vector3.up);
            MainCam.transform.rotation = rotation;

            MainCam.transform.position = Vector3.SmoothDamp(MainCam.transform.position, camMount.transform.position, ref velocity, smoothTime);
        }
    }

    private void OnMouseDown()
    {
        if (!moveIt)
        {
            print("clicked " + gameObject.name);
            moveIt = true;
        }
        
    }

    public Vector3 MoveCamera()
    {
        Vector3 loc = new Vector3();

        loc = camMount.transform.position;

        return loc;
    }

    public Vector3 RotateCamera(Vector3 cam)
    {
        Vector3 relPosition = transform.position - cam;

        return relPosition;
    }
}
