using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importar para usar la UI

public class HealthAndStamina : MonoBehaviour
{
    // Variables de vida y energ�a
    public float maxHealth = 100f;
    public float currentHealth;

    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 5f;  // Tasa de regeneraci�n por segundo
    public float staminaRegenDelay = 1f; // Retraso antes de comenzar la regeneraci�n
    private float staminaRegenCooldown = 0f;

    // Variables de combate
    public float normalAttackCost = 10f;
    public float heavyAttackCost = 25f;
    public float blockCostPerHit = 5f;

    private bool isBlocking = false;
    private bool isAttacking = false;
    private bool canAttack = true;  // Controla si el jugador puede atacar

    // Velocidad de ataque
    public float attackCooldown = 1f;  // Tiempo de espera entre ataques (en segundos)
    private bool isOnCooldown = false; // Controla si el ataque est� en cooldown

    // Control de ataques
    public float chargeTime = 0.5f;  // Tiempo m�nimo para considerar un ataque fuerte
    private float holdTime = 0f;      // Tiempo que el bot�n ha estado presionado

    // Referencias a los Sliders de la UI
    public Slider healthBar;
    public Slider staminaBar;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;

        // Inicializar las barras de vida y energ�a
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;
    }

    void Update()
    {
        HandleCombat();
        RegenerateStamina();
        UpdateUI(); // Actualizar la UI en cada frame
    }

    void HandleCombat()
    {
        // Bloquear con click derecho mantenido
        if (Input.GetMouseButton(1))
        {
            Block();
        }
        else
        {
            StopBlocking();
        }

        // Si el jugador est� en cooldown, no puede atacar
        if (isOnCooldown) return;

        // Aumentar el tiempo que el bot�n est� presionado
        if (Input.GetMouseButton(0))
        {
            holdTime += Time.deltaTime;
        }

        // Ataque fuerte con click izquierdo mantenido (si se mantiene por suficiente tiempo)
        if (Input.GetMouseButtonUp(0))
        {
            if (holdTime >= chargeTime && currentStamina >= heavyAttackCost && canAttack)
            {
                HeavyAttack();
            }
            else if (holdTime < chargeTime && currentStamina >= normalAttackCost && canAttack)
            {
                NormalAttack();
            }

            // Reseteamos el tiempo de mantener el bot�n y permitimos otro ataque
            holdTime = 0f;
            canAttack = true;
        }
    }

    void NormalAttack()
    {
        // Realizar el ataque normal
        Debug.Log("Ataque normal realizado");
        isAttacking = true;
        currentStamina -= normalAttackCost;
        staminaRegenCooldown = staminaRegenDelay;  // Reiniciar cooldown de regeneraci�n de energ�a

        // Iniciar cooldown del ataque
        StartCoroutine(AttackCooldown());

        // Simular la finalizaci�n del ataque para poder regenerar stamina
        StartCoroutine(EndAttack());
    }

    void HeavyAttack()
    {
        // Realizar el ataque fuerte
        Debug.Log("Ataque fuerte realizado");
        isAttacking = true;
        currentStamina -= heavyAttackCost;
        staminaRegenCooldown = staminaRegenDelay;  // Reiniciar cooldown de regeneraci�n de energ�a

        // Evitar que el jugador ataque sin soltar el click
        canAttack = false;

        // Iniciar cooldown del ataque
        StartCoroutine(AttackCooldown());

        // Simular la finalizaci�n del ataque para poder regenerar stamina
        StartCoroutine(EndAttack());
    }

    void Block()
    {
        // Levantar escudo para bloquear
        Debug.Log("Bloqueando");
        isBlocking = true;
        staminaRegenCooldown = staminaRegenDelay;  // Detener regeneraci�n de energ�a mientras se bloquea
    }

    void StopBlocking()
    {
        isBlocking = false;
    }

    // Corrutina para gestionar el cooldown de ataque
    IEnumerator AttackCooldown()
    {
        isOnCooldown = true;  // Deshabilita ataques mientras dura el cooldown
        yield return new WaitForSeconds(attackCooldown);  // Tiempo de espera entre ataques
        isOnCooldown = false;  // Permite atacar nuevamente
    }

    // Simular el final del ataque para permitir regeneraci�n de stamina
    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.5f); // Ajusta el tiempo seg�n lo que necesites para el ataque
        isAttacking = false;
    }

    // Este m�todo lo llamaremos al recibir un golpe mientras se bloquea
    public void TakeBlockHit()
    {
        if (isBlocking && currentStamina >= blockCostPerHit)
        {
            Debug.Log("Golpe bloqueado");
            currentStamina -= blockCostPerHit;
            staminaRegenCooldown = staminaRegenDelay;
        }
        else
        {
            // El jugador recibe da�o si no tiene suficiente energ�a para bloquear
            Debug.Log("No queda energ�a para bloquear, se recibe da�o");
            TakeDamage(10f); // Da�o recibido por no bloquear
        }
    }

    void RegenerateStamina()
    {
        // Verificar que no se est� atacando ni bloqueando, y que el cooldown ha terminado
        if (!isAttacking && !isBlocking && currentStamina < maxStamina && staminaRegenCooldown <= 0)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }
        else
        {
            staminaRegenCooldown -= Time.deltaTime;
        }
    }

    // M�todo para recibir da�o
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("El jugador ha muerto");
        // Implementar lo que ocurre cuando el jugador muere
    }

    // M�todo para actualizar la UI de las barras de vida y energ�a
    void UpdateUI()
    {
        healthBar.value = currentHealth;  // Actualizar la barra de vida
        staminaBar.value = currentStamina;  // Actualizar la barra de energ�a
    }
}