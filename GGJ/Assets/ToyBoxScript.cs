using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToyBoxScript : MonoBehaviour
{
    private int health = 110;
    public Image Healthbar;
    
    public void TakingDamage(int attackDamage)
    {
        health -= attackDamage;
        Debug.Log("Toybox health " + health.ToString());
        Healthbar.fillAmount = (health / 100f) + 0.1f;

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
