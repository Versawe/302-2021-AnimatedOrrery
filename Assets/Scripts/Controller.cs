using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float setRadius = 4;
    public float setMoonRadius = 0.5f;

    public List<GameObject> planets;
    public List<GameObject> moons;

    //public GameObject moon;

    public List<Button> buttons;
    // Start is called before the first frame update
    void Start()
    {

        //planet spacing
        foreach (GameObject planet in planets)
        {
            planet.GetComponent<RevolveAround>().radius = setRadius;
            planet.GetComponent<RevolveAround>().target = gameObject;
            setRadius += 2;
        }

        //moon spacing
        for (int i = 0; i < planets.Count; i++)
        {
            moons[i].GetComponent<RevolveAround>().target = planets[i];
            moons[i].GetComponent<RevolveAround>().radius = setMoonRadius;
            setMoonRadius += 0.5f;
            moons[i + 5].GetComponent<RevolveAround>().target = planets[i];
            moons[i + 5].GetComponent<RevolveAround>().radius = setMoonRadius;
            setMoonRadius = 0.5f;
        }
    }


    public void Show_Buttons()
    {
        foreach (Button butt in buttons)
        {
            butt.gameObject.SetActive(true);
        }
    }

    public void Hide_Buttons()
    {
        foreach (Button butt in buttons)
        {
            butt.gameObject.SetActive(false);
        }
    }

}
