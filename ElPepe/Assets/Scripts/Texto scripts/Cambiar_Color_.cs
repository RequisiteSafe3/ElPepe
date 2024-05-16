using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Cambiar_Color_ : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public void Cambiar()
    {
        spriteR.color = new Color(0.4078431f, 0.6862745f, 0.8431373f, 0.6980392f);
    }
}
