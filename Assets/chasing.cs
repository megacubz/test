using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasing : MonoBehaviour
{

    public GameObject ennmis; //l'ennemi qui chasse
    public GameObject ally; //le joueur chassé

    public float speed; //la vitesse
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ennmis.transform.position = Vector3.MoveTowards(ennmis.transform.position,ally.transform.position,speed); //déplacement vers le joueur
    }
}


