using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieScript : MonoBehaviour
{
    public float dieTime;
    public bool lastOne = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, dieTime);
    }
    
}
