using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI staminaText = default;

    private void OnEnable()
    {
        PlayerMovement.OnStaminaChange += UpdateStamina;
    }

    private void OnDisable()
    {
        PlayerMovement.OnStaminaChange -= UpdateStamina;
    }

    private void Start()
    {
        UpdateStamina(100);
    }

    private void UpdateStamina(float currentStamina)
    {
        staminaText.text = currentStamina.ToString("00");
    }
}
