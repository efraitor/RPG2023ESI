using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Posición del objetivo que debe seguir la cámara
    public Transform target;

    //Música a reproducir en esta escena
    public int musicToPlay;
    //Para comprobar si la música ya está sonando
    private bool musicStarted;

    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos el Transform del jugador
        target = FindObjectOfType<PlayerController>().transform;
    }

    // LateUpdate para evitar los problemas de glitcheo de la cámara al seguir al jugador
    void LateUpdate()
    {
        //Cámara sigue la posición del jugador
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //Si no ha empezado la música, le decimos que ahora sí y la reproducimos
        if(!musicStarted)
        {
            musicStarted = true;
            AudioManager.instance.PlayBGM(musicToPlay);
        }
    }
}
