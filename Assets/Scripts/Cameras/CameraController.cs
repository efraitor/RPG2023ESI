using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Posici�n del objetivo que debe seguir la c�mara
    public Transform target;

    //M�sica a reproducir en esta escena
    public int musicToPlay;
    //Para comprobar si la m�sica ya est� sonando
    private bool musicStarted;

    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos el Transform del jugador
        target = FindObjectOfType<PlayerController>().transform;
    }

    // LateUpdate para evitar los problemas de glitcheo de la c�mara al seguir al jugador
    void LateUpdate()
    {
        //C�mara sigue la posici�n del jugador
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //Si no ha empezado la m�sica, le decimos que ahora s� y la reproducimos
        if(!musicStarted)
        {
            musicStarted = true;
            AudioManager.instance.PlayBGM(musicToPlay);
        }
    }
}
