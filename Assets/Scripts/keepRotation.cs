using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepRotation : MonoBehaviour
{
    public Transform planet;
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(planet.position.x-3, planet.position.y+2,planet.position.z+2);
    }
}
