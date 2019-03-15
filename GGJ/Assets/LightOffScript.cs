using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOffScript : MonoBehaviour
{
    public GameObject directionalLight;
    public GameObject postprocessinglayer;
    GameObject hamada;
    bool done = false;

    void Start()
    {
        hamada = new GameObject();
        if (directionalLight == null)
        {
            Debug.LogError("please check your directional light object");
        }
        if (postprocessinglayer == null)
        {
            Debug.LogError("please check your directional light object");
        }
    }

    void Update()
    {
        if (done)
        {
            directionalLight.SetActive(false);
            hamada.GetComponentInChildren<EnemySettingsScript>().hitting = false;
            hamada.GetComponent<EnemySettingsScript>().IsLighOn = false;
            FindObjectOfType<GameManager>().myPP().enabled = true;
            postprocessinglayer.SetActive(true);
            hamada.GetComponent<EnemySettingsScript>().SetToyBoxTransform(FindObjectOfType<EnemyManager>().toyboxTransform);//FindObjectOfType<EnemyManager>().RespawnPoints[0].transform;
            
            done = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Enemy" && other.gameObject.layer == 11)
        {
        hamada = other.gameObject;
            hamada = other.gameObject;
            other.gameObject.GetComponentInChildren<EnemySettingsScript>().hitting = true;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        done = true;
    }
}
