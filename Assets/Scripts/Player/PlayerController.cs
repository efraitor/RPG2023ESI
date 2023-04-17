using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Velocidad de movimiento del jugador
    public float moveSpeed;

    //Nombre del área a la que vamos
    public string areaTransitionName;

    //Temporizador sin Input
    public float noMoveLength;
    private float noMoveCount;

    //Referencia al RigidBody del jugador
    private Rigidbody2D theRB;
    //Referencia al Animator del jugador
    public Animator anim;

    //Hacemos una referencia (Singleton)
    public static PlayerController instance;

    private void Awake()
    {
        //Inicializamos el Singleton si está vacío
        if (instance == null) instance = this;
        //Si no lo está
        else
        {
            //Si hay otro objeto que no sea este, es destruido (evitamos la duplicación del jugador en el cambio entre escenas)
            if (instance != this) Destroy(gameObject);
        }
        //Hace que el jugador no se destruido al cambiar entre escenas
        DontDestroyOnLoad(gameObject);
    }

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
        //Si el contador de tiempo sin Input está vacío
        if (noMoveCount <= 0)
        {
            //Movemos al personaje usando la velocidad de su RigidBody, obteniendo los Inputs de los ejes de movimiento
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed; //Con normalized conseguimos que la diagonal también tenga valor 1

            //Si hemos pulsado cualquiera de los botones de dirección
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                //Metemos como última posición en X e Y el último input realizado
                anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }
        //Si el contador aún está lleno
        else
            noMoveCount -= Time.deltaTime;

        //ANIMACIONES
        anim.SetFloat("moveX", theRB.velocity.x);
        anim.SetFloat("moveY", theRB.velocity.y);
    }

    //Método para inicializar el contador
    public void InitializeNoInput()
    {
        //Inicializamos el contador de no Input
        noMoveCount = noMoveLength;
        //Paramos al jugador
        theRB.velocity = Vector2.zero;
    }

}