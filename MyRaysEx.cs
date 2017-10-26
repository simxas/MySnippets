using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRaysEx : MonoBehaviour
{
    public float RayLength = 10;

    public int LayerMask = 0;

    public List<Vector3> RayHitPositions = new List<Vector3>();

    // Use this for initialization
    void Start()
    {
        LayerMask = 1 << LayerMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up, 20f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up, -20f * Time.deltaTime);
        }

        RayHitPositions.Clear();

        DrawRayAndHit();

        //hit all object on specified layer
        //DrawRayHitAll();
    }

    void DrawRayAndHit()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, RayLength, LayerMask))
        {
            //a hit!
            Debug.DrawLine(this.transform.position, hitInfo.point, Color.red, .01f, true);
            RayHitPositions.Add(hitInfo.point);
            Debug.Log(hitInfo.collider.gameObject.layer);
        }
        else
        {
            Debug.DrawLine(this.transform.position, this.transform.forward * RayLength, Color.green, .01f, true);
        }
    }

    void DrawRayAndHitAll()
    {
        Debug.DrawLine(this.transform.position, this.transform.forward * RayLength, Color.green, .01f, true);
        RaycastHit[] hits = Physics.RaycastAll(this.transform.position, this.transform.forward, RayLength, LayerMask);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                //a hit!
                Debug.DrawLine(this.transform.position, hit.point, Color.red, .01f, true);
                RayHitPositions.Add(hit.point);
            }
        }
    }

    void OnDrawGizmos()
    {
        //Draw the hit locations
        foreach (Vector3 sphereHitPosition in RayHitPositions)
        {
            Gizmos.DrawWireSphere(sphereHitPosition, .5f);
        }
    }

}