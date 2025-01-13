using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundcontroll : MonoBehaviour
{
    private float StartPos, taille; //déclaration de la vitesse et de la taille du fond

    public GameObject cam; //déclaration de l'objet caméra

    public float parallax; //vitesse de déplacement
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x; //position initiale du fond
        taille = GetComponent<SpriteRenderer>().bounds.size.x; //récupération de la taille du fond
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallax; //distance parcouru en fonction du facteur de parallaxe
        float mouvement = cam.transform.position.x * (1-parallax); //mouvement dû à l'effet de parallaxe

        transform.position = new Vector3(StartPos + distance, transform.position.y, transform.position.z); //application de l'effet


        //si le joueur dépasse les limites du fond, déplacer le fond en conséquence
        if (mouvement > StartPos + taille){
            StartPos += taille;
        }
        else if (mouvement < StartPos - taille){
            StartPos -= taille;
        }
    }
}

