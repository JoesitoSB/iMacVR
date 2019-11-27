using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[System.Serializable]
public class CancionesClass
{
    public AudioClip Cancion;
    public string Nombre;
    public string Artista;
    public Sprite AlbumArt;

    [HideInInspector]
    public AudioSource source;
}
