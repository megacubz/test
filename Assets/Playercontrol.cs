using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    public float movSpeed; // initialisation de la vitesse du joueur
    float speedx; //initialisation de la vitesse horizontale du joueur

    float saut = 40f; //initialisation de la force du saut

    bool saute = false; //suivre l'état du joueur, en l'air ou non
    Rigidbody2D rb; // déclaration du joueur

    bool facingleft = false; //vérification du sens du sprite
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //récupération du sprite
    }


    // Update is called once per frame
    void Update()
    {
        speedx = Input.GetAxis("Horizontal"); //récupération de  la vitesse horizontale
        FlipSprite(); //appelle de flipsprite
        if(Input.GetButtonDown("Jump") && !saute){
            rb.velocity = new Vector2 (rb.velocity.x, saut);  //gestion des sauts
            saute=true;
        }

    }
private void FixedUpdate() {
    rb.velocity = new Vector2(speedx * movSpeed, rb.velocity.y);  
}
void FlipSprite(){
    if (facingleft && speedx >0f || !facingleft && speedx < 0f){ //vérifie si ça change de direction
        facingleft = !facingleft; //changement de côté
        Vector3 ls = transform.lossyScale; //lis les bornes du sprite
        ls.x *= -1f; //retourne le sprite sur l'axe x
        transform.localScale = ls; //applique le changement
    }
}
private void OnCollisionEnter2D(Collision2D collision){
    saute =    false; //si il touche quelque chose, n'est plus en saut
}

}
      
    
