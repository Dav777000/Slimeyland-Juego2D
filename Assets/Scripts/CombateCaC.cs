using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    private float tiempoSiguienteAtaque;
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        tiempoSiguienteAtaque = 0f; // Inicializar el tiempoSiguienteAtaque en el Start
    }

    private void Update()
    {
        // Decrementar el tiempoSiguienteAtaque si es mayor que cero
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        // Realizar el golpe si se presiona el botón de ataque y ha pasado suficiente tiempo
        if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Golpe"); // Activar la animación de golpe

        Collider2D[] objectsHit = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D collider in objectsHit)
        {
            if (collider.CompareTag("Enemigo"))
            {
                Enemigo enemy = collider.GetComponent<Enemigo>();
                if (enemy != null)
                {
                    enemy.TomarDaño(dañoGolpe);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Dibujar un gizmo de color rojo para mostrar el radio de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}