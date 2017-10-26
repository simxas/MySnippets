using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMyTexture : MonoBehaviour
{
    private Texture2D MyTexture;

    public Color MyCollor;

    // Use this for initialization
    void Start()
    {
        MyTexture = MyTextureMaker.MakeTexture((int) gameObject.GetComponent<Renderer>().bounds.size.x,
            (int) gameObject.GetComponent<Renderer>().bounds.size.y, MyCollor);

        gameObject.GetComponent<Renderer>().material.mainTexture = MyTexture;
    }

    // Update is called once per frame
    void Update()
    {
    }
}