using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateformequibouge : MonoBehaviour
{
    public GameObject ennmis; // La plateforme
    public GameObject ally;   // Le personnage à suivre

    public float speed; // Vitesse de la plateforme

    void Start (){

    }

    // Update is called once per frame
    void Update()
    {
        // Récupérer la position actuelle de la plateforme et du personnage
        Vector3 currentPlatformPosition = ennmis.transform.position;
        Vector3 targetPosition = ally.transform.position;

        // Ne suivre que sur l'axe X
        Vector3 newPosition = Vector3.MoveTowards(
            currentPlatformPosition,
            new Vector3(targetPosition.x, currentPlatformPosition.y, currentPlatformPosition.z),
            speed * Time.deltaTime // Vitesse ajustée par le temps
        );

        // Appliquer la nouvelle position à la plateforme
        ennmis.transform.position = newPosition;
    }
}

