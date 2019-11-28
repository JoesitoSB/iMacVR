using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CambiarTiempoVideo : MonoBehaviour
{
    public void AgregarTiempo(VideoPlayer _VideoPlayer, float _TiempoAgregado, float MyVideoTime)
    {
        if(_TiempoAgregado == MyVideoTime)
        {
            _VideoPlayer.time += _TiempoAgregado;
        }
        else
        {
            double _VideoTime = _VideoPlayer.clip.length;
            double _NewTime = _VideoPlayer.time += _TiempoAgregado;
            if (_NewTime < _VideoTime && _TiempoAgregado > 0)
            {
                _VideoPlayer.time += _TiempoAgregado;
            }
        }
    }
}
