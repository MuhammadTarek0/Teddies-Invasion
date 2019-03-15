
using UnityEngine;
using UnityEditor;
public class eventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUI.enabled = Application.isPlaying;

        gameEvent e = target as gameEvent;
        if(GUILayout.Button("Raise"))
        {
            e.raise();
        }
    }
}
