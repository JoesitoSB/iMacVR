using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class ClaseAudio
{
    public AudioClip clip;
    public string Nombre;
    public string Artista;

    [HideInInspector]
    public AudioSource source;

}