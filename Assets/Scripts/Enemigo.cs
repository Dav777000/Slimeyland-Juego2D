using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            EjecutarMuerte();
        }
    }

    private void EjecutarMuerte()
    {
        animator.SetTrigger("Muerte");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CombateJugador jugador = collision.gameObject.GetComponent<CombateJugador>();
            if (jugador != null)
            {
                jugador.TomarDaño(20);
            }
        }
    }
}