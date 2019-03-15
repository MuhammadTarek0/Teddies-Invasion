using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointsScript : MonoBehaviour
{
    public Transform nextTarget;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Towards " + nextTarget.name);
            col.gameObject.GetComponent<EnemySettingsScript>().SetToyBoxTransform(nextTarget);
        }
    }
}
