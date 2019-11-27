using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarSprite : MonoBehaviour
{
    public void ChangeSprite(Image _ImageRenderer, Sprite _ChangeTo)
    {
        _ImageRenderer.sprite = _ChangeTo;
    }
}
