using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEventsSubscriber : MonoBehaviour {

    void OnEnable()
    {
        MyEventsPublisher.ObjectStopped += this.OnObjectStopped;
    }

    public void OnObjectStopped(object source, EventArgs e)
    {
        Destroy(this.gameObject);
        Debug.Log("Event done");
    }
}
