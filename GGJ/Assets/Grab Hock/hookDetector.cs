using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookDetector : MonoBehaviour
{
    public GameObject player;
    public gameEvent hitGrappable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hookable")
        {
            Debug.Log("Here bitches");
            player.GetComponent<hookGrap>().hooked = true;
            player.GetComponent<hookGrap>().hookedObject = other.gameObject;
        }
    }
}
