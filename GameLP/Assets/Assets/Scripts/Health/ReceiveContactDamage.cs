using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[DisallowMultipleComponent]

public class ReceiveContactDamage : MonoBehaviour
{
    #region Header 
    [Header("The contact damaege amount to receive")]
    #endregion 
    [SerializeField] private int contactDamageAmount;
    private Health health;

    private void Awake() {
        health = GetComponent<Health>();
    }

    public void TakeContactDamge(int damageAmount = 0)
    {
        if(contactDamageAmount > 0)
        {
            damageAmount = contactDamageAmount;

            Debug.Log("Potencial contact damage of " + damageAmount);

            health.TakeDamage(damageAmount);
        }
    }

    private void OnValidate() {
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(contactDamageAmount), contactDamageAmount, false);
    }
}
