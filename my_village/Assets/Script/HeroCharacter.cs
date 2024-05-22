using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCharacter : MonoBehaviour
{
    //VAriables
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    
    Vector2 dir;

    int dirValue = 0; //0 = Idl,  1 = Down,  2 = side,  3 = Up


    // Update is called once per frame
    void Update()
    {
        HandleKeys();
        HandleMove();
    }

    //Fonction custom
    public void HandleKeys()
    {
        if (Input.GetKey(KeyCode.DownArrow))  //Descendre 
        {
            dir = Vector2.down;
            dirValue = 1;

        }
        else if (Input.GetKey(KeyCode.UpArrow)) //Monter
        {
            dir = Vector2.up;
            dirValue = 3;
        }
        else if (Input.GetKey(KeyCode.RightArrow))  //Droite
        {
            dir = Vector2.right;
            dirValue = 2;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))  //Gauche
        {
            dir = Vector2.left;
            dirValue = 2;
            spriteRenderer.flipX = false;

        }
        else  //rien
        {
            dir = Vector2.zero;
        }

    }

    public void HandleMove()
    {
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
        animator.SetInteger("dir", dirValue);
    }

}
