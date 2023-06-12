using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLevelChecker : MonoBehaviour
{

    public float requiredLevel, slowFactor;
    public PlayerLevelManager LevelScript;

    private void Start()
    {
        LevelScript = GameObject.FindObjectOfType<PlayerLevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide!");

        if (other.tag == "Player")
        {
            if(requiredLevel > LevelScript.currentLevel)
            {
                other.attachedRigidbody.velocity -= other.attachedRigidbody.velocity * slowFactor* Time.deltaTime;
                // -= other.attachedRigidbody.velocity * slowTime * Time.deltaTime;



            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        other.attachedRigidbody.GetComponent<BaseInput>().LockInputForAWhile(0.5f, false);

    }

}
