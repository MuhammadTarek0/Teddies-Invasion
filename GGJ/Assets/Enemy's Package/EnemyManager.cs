using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Header("Enemies Settings")]
    public List<GameObject> enemiesPrefabs;
    public List<GameObject> RespawnPoints;
    [Space]
    [Header("Game Settings")]
    public Transform playerTransform;
    public Transform toyboxTransform;
    public Transform lightTransform;

    private GameObject[] myEnemies;

    float startTime = 0;
    public float waitFor = 4;
    int counter = 0;

    void Start()
    {
        Debug.Log("Lets the game Start bbe");
        for (int i = 0; i < enemiesPrefabs.Count; i++)
        {
            if (enemiesPrefabs[i] == null)
            {
                Debug.LogError("Please check element number " + i + " in  Enemies prefabs list");
            }

            else if (enemiesPrefabs[i].layer == 11)
            {
                enemiesPrefabs[i].GetComponent<EnemySettingsScript>().SetLightTransform(lightTransform);
            }
            else
            {
                enemiesPrefabs[i].GetComponent<EnemySettingsScript>().SetLightTransform(toyboxTransform);
            }

            enemiesPrefabs[i].GetComponent<EnemySettingsScript>().SetPlayerTransform(playerTransform);
            enemiesPrefabs[i].GetComponent<EnemySettingsScript>().SetToyBoxTransform(toyboxTransform);
        }
        myEnemies = LoadMyLevels(3);
    }


    void Update()
    {
        
       
        if (Time.time - startTime >= waitFor && counter <= (myEnemies.Length - 1))
        {
            Debug.Log("Cop Created");
            Instantiate(myEnemies[counter], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
            counter++;
            startTime = Time.time;
        }

        
        //if (myEnemies.Length == 0)
        //{
        //    myEnemies = LoadMyLevels(2);
        //    for (int i = 0; i < myEnemies.Length; i++)
        //    {
        //        waitFor = 8;

        //        if (Time.time - startTime > waitFor)
        //        {
        //        Instantiate(myEnemies[i], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
        //            startTime = Time.time;
        //        }
        //    }
        //}
    }

    GameObject[] LoadMyLevels(int levelNumber)
    {
        GameObject[] levelEnemies;

        switch (levelNumber)
        {
            case 1:
                {
                    Debug.Log("First wave begins");
                    levelEnemies = new GameObject[1];
                    levelEnemies[0] = enemiesPrefabs[2];
                    return levelEnemies;
                }
            case 2:
                {
                    Debug.Log("First wave end");
                    Debug.Log("Second wave begins");
                    levelEnemies = new GameObject[10];
                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 9)
                        {
                            Debug.Log("LastOne");
                        }

                        levelEnemies[i] = enemiesPrefabs[0];

                    }
                    return levelEnemies;
                }
            case 3:
                {
                    Debug.Log("Second wave end");
                    Debug.Log("Third wave begins");
                    levelEnemies = new GameObject[25];
                    for (int i = 0; i < 25; i++)
                    {
                        if (i == 24)
                        {
                            levelEnemies[i] = enemiesPrefabs[1];
                        }
                        else
                        {
                            if (i % 4 != 0)
                            {
                                levelEnemies[i] = enemiesPrefabs[0];
                            }
                            else
                            {
                                levelEnemies[i] = enemiesPrefabs[1];
                            }
                        }
                    }
                    return levelEnemies;
                }
            case 4:
                {
                    Debug.Log("Third wave end");
                    Debug.Log("Forth wave begins");
                    levelEnemies = new GameObject[60];
                    for (int i = 0; i < 60; i++)
                    {
                        if (i == 59)
                        {
                            Debug.Log("LastOne");
                            levelEnemies[i] = enemiesPrefabs[0];

                        }
                        else
                        {
                            if (i == 15 || i == 40)
                            {
                                levelEnemies[i] = enemiesPrefabs[2];
                            }
                            else if (i % 11 != 0)
                            {
                                levelEnemies[i] = enemiesPrefabs[0];
                            }
                            else
                            {
                                for (int k = 0; k < 3; k++)
                                {
                                    levelEnemies[i] = enemiesPrefabs[1];
                                }
                            }
                        }

                    }
                    return levelEnemies;
                }
            case 5:
                {
                    Debug.Log("Boss wave begins");
                    levelEnemies = new GameObject[1];
                    levelEnemies[0] = enemiesPrefabs[3];
                    return levelEnemies;
                }
            default:
                {
                    return new GameObject[0];
                }
                
        }
    }
    /*
    void Wave1()
    {
        Debug.Log("First wave began");
        Instantiate(enemiesPrefabs[2], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
    }
    void Wave2()
    {
        bool waving = false;

        Debug.Log("First wave end");
        Debug.Log("Second wave begins");

        for (int i = 0; i < 10; i++)
        {
            if (i == 9)
            {
                Debug.Log("LastOne");
                Instantiate(enemiesPrefabs[0], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
            }

            else
            {
                if (i % 4 != 0)
                {
                    StartCoroutine(waitfor(1, waving));
                    if (waving)
                    {
                        Instantiate(enemiesPrefabs[0], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                        waving = false;
                    }
                }
                else
                {
                    StartCoroutine(waitfor(10, waving));
                    if (waving)
                    {
                        Instantiate(enemiesPrefabs[0], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                        waving = false;
                    }
                }
            }
        }
    }
   IEnumerator Wave3()
    {
        Debug.Log("Second wave end");
        Debug.Log("Third wave begins");
       
            for (int i = 0; i < 25; i++)
            {
                if (i == 24)
                {
                    Instantiate(enemiesPrefabs[1], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                    yield return new WaitForSeconds(30);
                    Debug.Log("Third wave end");
                    StartCoroutine(Wave4());

                }
                else
                {
                    if (i % 4 != 0)
                    {
                        Instantiate(enemiesPrefabs[0], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                    }
                    else
                    {
                        Instantiate(enemiesPrefabs[1], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                        yield return new WaitForSeconds(10);
                    }
                }
            }
        
    }
   IEnumerator Wave4()
    {
        Debug.Log("Third wave end");
        Debug.Log("Forth wave begins");

        //Wave 4 all kind of enemies
        
            for (int i = 0; i < 60; i++)
            {
                if (i == 59)
                {
                    Debug.Log("LastOne");
                    Instantiate(enemiesPrefabs[0], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                    yield return new WaitForSeconds(30);
                    Debug.Log("Forth wave end");
                    StartCoroutine(Wave5());
                    
                }
                else
                {
                    if (i == 15 || i == 40)
                    {
                        Instantiate(enemiesPrefabs[2], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                    }
                    else if (i % 11 != 0)
                    {
                        Instantiate(enemiesPrefabs[0], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                    }
                    else
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            Instantiate(enemiesPrefabs[1], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                        }

                        yield return new WaitForSeconds(10);
                    }
                }

            }
        
    }
   IEnumerator Wave5()
    {
        //Wave 5 the boss fight
        GameObject Boss = new GameObject();
            Boss = Instantiate(enemiesPrefabs[3], RespawnPoints[(int)Random.Range(0, RespawnPoints.Count)].transform.position, Quaternion.Euler(Vector3.zero));
        if (Boss == null)
        {
            yield return new WaitForSeconds(9);
        }
    }
    */
   
}