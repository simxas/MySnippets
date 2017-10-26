using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEventsPublisher : MonoBehaviour {

    public delegate void ObjectStoppedEventHandler(object source, EventArgs args);

    public static event ObjectStoppedEventHandler ObjectStopped;

    public void OnMouseDown()
    {
        StartCoroutine(Movement());
    }

    public IEnumerator Movement()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.Translate(0f, -.1f, 0f);
            yield return 0; // bam this one goes for one frame
        }

        OnObjectStopped();

    }

    public void OnObjectStopped()
    {
        if (ObjectStopped != null)
        {
            ObjectStopped(this, EventArgs.Empty); //im not passing any data
        }
    }
}
