using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class eventListners : MonoBehaviour
{
    public gameEvent Event ;
    public UnityEvent response;
    private void OnEnable()
    {
        Event.register(this);
    }
    private void OnDisable()
    {
        Event.unregister(this);
    }
    public void onEventRaise()
    {
        response.Invoke();
    }
}
