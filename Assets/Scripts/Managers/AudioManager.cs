using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Arrays para los sonidos y la música del juego
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    //Hacemos una referencia(Singleton)
    public static AudioManager instance;
    private void Awake()
    {
        //Inicializamos el Singleton si está vacío
        if (instance == null) instance = this;
        //Hace que el AudioManager no sea destruido al cambiar entre escenas
        DontDestroyOnLoad(gameObject);
    }

    //Método para reproducir un sonido pasado por parámetro
    public void PlaySFX(int soundToPlay)
    {
        //Sólo si el sonido existe, lo para por si ya estuviera sonando, y lo reproduce
        if(soundToPlay < sfx.Length)
        {
            sfx[soundToPlay].Stop();
            sfx[soundToPlay].Play();
        }
    }

    //Método que reproduce una música pasada por parámetro
    public void PlayBGM(int musicToPlay)
    {
        //Si no se está reproduciendo ya la música que queremos, se paran todas y se reproduce la seleccionada
        if (!bgm[musicToPlay].isPlaying)
        {
            StopMusic();

            if (musicToPlay < bgm.Length)
                bgm[musicToPlay].Play();
        }
    }

    //Método que para toda la música
    public void StopMusic()
    {
        //Para cualquier música que estuviera sonando
        for (int i = 0; i < bgm.Length; i++)
            //Paramos esa música concreta
            bgm[i].Stop();
    }
}
