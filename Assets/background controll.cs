using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundcontroll : MonoBehaviour
{
    private float StartPos, taille;

    public GameObject cam;

    public float parallax;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        taille = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallax;
        float mouvement = cam.transform.position.x * (1-parallax);

        transform.position = new Vector3(StartPos + distance, transform.position.y, transform.position.z);

        if (mouvement > StartPos + taille){
            StartPos += taille;
        }
        else if (mouvement < StartPos - taille){
            StartPos -= taille;
        }
    }
}
