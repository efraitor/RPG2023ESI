using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Librer�a para el cambio entre escenas

public class ExitArea : MonoBehaviour
{
    //Nombre de la escena a cargar
    public string sceneToLoad;

    //El nombre del �rea de la escena a la que vamos a ir
    public string areaTransitionName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo para conocer cuando el jugador entra en el �rea de cambio de nivel
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Cargamos la escena a la que queremos ir
            SceneManager.LoadScene(sceneToLoad);

            //El jugador recoge el �rea a la que quiere ir de la salida que est� pisando
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
