using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Tapa : MonoBehaviour
{
    private bool pene = false;
    public GameObject Tapa_Abierta;
    public GameObject Tapa_Cerrada;
    public ParticleSystem Ps;
    public ParticleSystem Ps2;
    public ParticleSystem Ps3;
    public ParticleSystem Ps4;
    public ParticleSystem lluvia1;
    public ParticleSystem lluvia2;
    public ParticleSystem lluvia3;
    public ParticleSystem lluvia4;
    public ParticleSystem lluvia5;
    public ParticleSystem lluvia6;
    public GameObject lluvia;
    public Echo echo;
    void Update()
    {
        if (pene == true)
        {
            Cerrar();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pene = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pene = false;
        }
    }
    private void Cerrar()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            echo.Aire_Reparado++;
            Tapa_Cerrada.gameObject.SetActive(true);
            Tapa_Abierta.gameObject.SetActive(false);
            lluvia.gameObject.SetActive(false);
            var p = Ps.main;
            var p2 = Ps2.main;
            var p3 = Ps3.main;
            var p4 = Ps4.main;
            var l1 = lluvia1.main;
            var l2 = lluvia2.main;
            var l3 = lluvia3.main;
            var l4 = lluvia4.main;
            var l5 = lluvia5.main;
            var l6 = lluvia6.main;
            p.loop = false;
            p2.loop = false;
            p3.loop = false;
            p4.loop = false;
            l1.loop = false;
            l2.loop = false;
            l3.loop = false;
            l4.loop = false;
            l5.loop = false;
            l6.loop = false;
            p.startLifetime = .5f;
            p2.startLifetime = .5f;
            p3.startLifetime = .5f;
            p4.startLifetime = .5f;
            l1.startLifetime = 4f;
            l2.startLifetime = 4f;
            l3.startLifetime = 4f;
            l4.startLifetime = 4f;
            l5.startLifetime = 4f;
            l6.startLifetime = 4f;
        }
    }
}
