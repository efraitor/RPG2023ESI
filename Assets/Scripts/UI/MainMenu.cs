using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Escena a la que vamos al empezar el juego
    public string newGameScene;

    // Start is called before the first frame update
    void Start()
    {
        //Bloqueamos el movimiento del jugador
        PlayerController.instance.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Si pulsamos la tecla Intro empieza el juego. Si pulsamos Escape se cierra
    
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //Desbloqueamos el movimiento del jugador
            PlayerController.instance.canMove = true;
            SceneManager.LoadScene(newGameScene);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Exit game");
        }
    }

}
