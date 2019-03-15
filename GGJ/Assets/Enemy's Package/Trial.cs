using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : MonoBehaviour
{
    public GameObject mine2;

    float startTime = 0;
    public float waitFor = 4;
    bool timerStart = true;

    private void Update()
    {
        //if (Time.time - startTime > waitFor)
        //{
        //    Instantiate(mine2, this.transform);
        //    startTime = Time.time;
        //}
        for (int i = 0; i < 10; i++)
        {
            if (i % 4 != 0)
            {
                waitFor = 4;
                if (Time.time - startTime >= waitFor)
                {
                    Instantiate(mine2, this.transform.position, Quaternion.Euler(Vector3.zero));
                    startTime = Time.time;
                }
            }
            else
            {
                waitFor = 15;
                if (Time.time - startTime >= waitFor)
                {
                    Instantiate(mine2, this.transform.position, Quaternion.Euler(Vector3.zero));
                    startTime = Time.time;
                }
            }
        }
    }
    
}
