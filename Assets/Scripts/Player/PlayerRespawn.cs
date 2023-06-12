using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float Ythreshold;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < Ythreshold)
        {
            transform.position = new Vector3(22f, 20f, 6f);
        }
    }
}
