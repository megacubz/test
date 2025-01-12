using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{


    public float movSpeed = 5f;
    float speedx;

    float saut = 40f;

    bool saute = false;
    Rigidbody2D rb;

    bool facingleft = false;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        speedx = Input.GetAxis("Horizontal");
        FlipSprite();
        if(Input.GetButtonDown("Jump") && !saute){
            rb.velocity = new Vector2 (rb.velocity.x, saut);
            saute=true;
        }

    }
private void FixedUpdate() {
    rb.velocity = new Vector2(speedx * movSpeed, rb.velocity.y);
}

void FlipSprite(){
    if (facingleft && speedx >0f || !facingleft && speedx < 0f){
        facingleft = !facingleft;
        Vector3 ls = transform.lossyScale;
        ls.x *= -1f;
        transform.localScale = ls;
    }
}

private void OnCollisionEnter2D(Collision2D collision){
    saute =    false;
}

}
      
    
