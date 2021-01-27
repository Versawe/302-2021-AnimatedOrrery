using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject sun;

    public static bool moveIt = false;

    Vector3 relPos;

    // Start is called before the first frame update
    void Start()
    {
        relPos = sun.transform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relPos, Vector3.up);

        transform.rotation = rotation;
    }

}
