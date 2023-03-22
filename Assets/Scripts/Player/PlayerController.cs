using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Velocidad de movimiento del jugador
    public float moveSpeed;

    //Referencia al RigidBody del jugador
    private Rigidbody2D theRB;
    //Referencia al Animator del jugador
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        //Inicializamos el RigidBody del jugador
        theRB = GetComponent<Rigidbody2D>();
        //Inicializamos el Animator del jugador
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movemos al personaje usando la velocidad de su RigidBody, obteniendo los Inputs de los ejes de movimiento
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed; //Con normalized conseguimos que la diagonal también tenga valor 1

        //ANIMACIONES
        anim.SetFloat("moveX", theRB.velocity.x);
        anim.SetFloat("moveY", theRB.velocity.y);

        //Si hemos pulsado cualquiera de los botones de dirección
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            //Metemos como última posición en X e Y el último input realizado
            anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

}