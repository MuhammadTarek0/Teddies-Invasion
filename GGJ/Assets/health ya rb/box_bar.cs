using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class box_bar : MonoBehaviour
{
    public Image Healthbar;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Healthbar.fillAmount -= 0.1f;
        }
    }
}
