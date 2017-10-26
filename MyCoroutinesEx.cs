using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoroutinesEx : MonoBehaviour
{
    private bool _startHeavy = false;

    public void OnMouseDown()
    {
        StartCoroutine(Movement());
        //StartCoroutine(Pulse());
        _startHeavy = true;
        StartHeavyTask();
    }

    public void StartHeavyTask()
    {
        if (_startHeavy)
            StartCoroutine(PseudoHeavyTask());
    }

    public IEnumerator Movement()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.Translate(.1f, 0f, 0f);
            yield return 0; // bam this one goes for one frame
        }

        //reset position at the end
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("Object back to start position");
    }

    public IEnumerator Pulse()
    {
        bool scaled = false;
        while (true)
        {
            if (scaled)
            {
                transform.localScale = new Vector3(2f, 2f, 2f);
            }
            else
            {
                this.transform.localScale = new Vector3(.5f, .5f, .5f);
            }
            scaled = !scaled;

            yield return new WaitForSeconds(1f); //executes for one sec
        }
    }

    public IEnumerator PseudoHeavyTask()
    {
        int processed = 0;
        int maxProcessed = 100;

        while (processed < maxProcessed)
        {
            Process();
            processed++;
            yield return 0;
        }

        Debug.Log("Completed heavy stuff");
    }

    //work on that CPU
    private void Process()
    {
        double t = double.MinValue;
        for (int i = 0; i < int.MaxValue / 1000f; i++)
        {
            t = Mathf.Sqrt(i);
        }
    }
}