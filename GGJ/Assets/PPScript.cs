using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPScript : MonoBehaviour
{
    public float time = 5;
    public GameObject cops;
    
    void Start()
    {
        StartCoroutine(function(time));
    }

    IEnumerator function(float f)
    {
        yield return new WaitForSeconds(f);
        FindObjectOfType<GameManager>().myPP().enabled = true;
        yield return new WaitForSeconds(4f);
        FindObjectOfType<GameManager>().myPP().enabled = false;
        yield return new WaitForSeconds(1f);
        FindObjectOfType<Camera>().GetComponent<Animator>().Play("CameraAnim");
        yield return new WaitForSeconds(3f);
        FindObjectOfType<Camera>().GetComponent<Animator>().Play("CameraAnim");
        cops.SetActive(true);

    }
}
