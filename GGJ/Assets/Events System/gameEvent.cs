using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class gameEvent : ScriptableObject
{
  public List<eventListners> listners = new List<eventListners>();

    public void raise()
    {
        Debug.Log("Raise Enter");

        for (int i = 0; i < listners.Count; i++)
        {
            listners[i].onEventRaise();
        }
    }
    public void register (eventListners listner)
    {
        if(!listners.Contains(listner))
        {
            listners.Add(listner);
        }
    }
    public void unregister(eventListners listner)
    {
        if (listners.Contains(listner))
        {
            listners.Remove(listner);
        }
    }
}
