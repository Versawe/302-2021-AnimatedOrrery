using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    private float timer = 5;

    public GameObject planet;
    public ParticleSystem p;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(p, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
