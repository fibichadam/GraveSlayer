using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text currentHealthText;

    public void UpdateHealth(int currentHealth)
    {
        currentHealthText.text = currentHealth.ToString();
    }

}
