using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class RespawnPoints : MonoBehaviour
{
    [SerializeField] Transform nextPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (nextPoint != null)
        {
            FindObjectOfType<EnemyManager>().toyboxTransform = nextPoint;
        }
    }
}
