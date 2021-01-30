using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static float setRadius = 4;
    public float setMoonRadius = 0.5f;

    public List<GameObject> planets;
    public List<GameObject> moons;

    public LineRenderer line;
    public List<LineRenderer> lines;
    private int vertex = 30;
    public float radius = 5;
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

            //also create line
            Instantiate(line, transform.position, transform.rotation);
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

    private void GeneratePoints()
    {
        line = GetComponent<LineRenderer>();

        //generate points
        float rad = 0;

        Vector3[] pts = new Vector3[vertex];

        for (int i = 0; i < vertex; i++)
        {
            pts[i] = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius + transform.position;
            rad += Mathf.PI * 2 / vertex; // increases the angle
        }
        line.positionCount = vertex;
        line.SetPositions(pts);
    }

}
