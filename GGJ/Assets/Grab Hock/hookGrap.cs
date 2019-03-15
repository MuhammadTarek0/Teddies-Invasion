using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookGrap : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;
    public GameObject hookedObject;
    public bool grounded;

    
    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public float maxDistace;
    float currentDistance;

    public static bool fire;
    public  bool hooked;

    bool fuck = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !fire)
        {
            fire = true;
        }

        if (fire && !hooked)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = returnCurrentDistance();
            if (currentDistance >= maxDistace)
            {
            returnHook();
            }
        }

        if (hooked)
        {
            hook.transform.position = hookedObject.transform.position;
            GetComponent<CharacterController>().enabled = false;
           transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, playerTravelSpeed * Time.deltaTime);           
           currentDistance = returnCurrentDistance();
            if (currentDistance < 2)
            {
            checkGrounded();
                if (!grounded)
                {
                   
                    transform.Translate(Vector3.forward * Time.deltaTime * 10f);
                    transform.Translate(Vector3.up * Time.deltaTime * 10f);
                }
                StartCoroutine(climb());
                
                hook.transform.position = hookHolder.transform.position;
               
            }
            
        }
       
    }
    IEnumerator climb()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<CharacterController>().enabled = true;
        returnHook();
    }
    void returnHook()
    {
       
        hook.transform.position = hookHolder.transform.position;
        fire = false;
        hooked = false;
    }
  
  float returnCurrentDistance()
    {

        return  Vector3.Distance(transform.position, hook.transform.position);
    }
   
         void checkGrounded()
    {
        RaycastHit hit;
        float distance = 0.8f;
        Vector2 dir = new Vector2(0, -1);
        if(Physics.Raycast(transform.position,dir,out hit,distance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
