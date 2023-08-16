using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximaVida; // Cambié el nombre de la variable para seguir las convenciones de nomenclatura
    [SerializeField] private BarraDeVida barraDeVida;
    
    private MovimientoJugador movimientoJugador;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;

    private void Start()
    {
        movimientoJugador = GetComponent<MovimientoJugador>();
        animator = GetComponent<Animator>();

        vida = maximaVida;
        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TomarDaño(float daño, Vector2 posicion)
    {
        vida -= daño;
        animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl());
        StartCoroutine(DesactivarColision());
        movimientoJugador.Rebote(posicion);
    }

    private IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    private IEnumerator PerderControl()
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;
    }
}