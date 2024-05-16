using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Cambiar_Color : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public void Cambiar()
    {
        spriteR.color = new Color(0.4078431f, 0.6862745f, 0.8431373f, 0.6980392f);
    }
}
