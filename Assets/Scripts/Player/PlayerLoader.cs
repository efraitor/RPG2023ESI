using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    //Referencia al objeto jugador
    public GameObject player;
    //Posición de aparición del jugador
    public Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        //Si a priori no hay ningun Player en la escena
        if (PlayerController.instance == null)
            //Instanciamos uno nuevo
            Instantiate(player, initialPos, transform.rotation);
        //Si existe un jugador en la escena
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
