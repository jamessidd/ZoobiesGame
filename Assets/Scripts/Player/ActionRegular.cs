using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRegular : MonoBehaviour
{
    BasePhysics Player;
    public Transform Model;

    public float skinRotationSpeed = 35;
    Quaternion CharRot;

    public float SkiddingStartPoint = 5;
    public float SkiddingIntensity = -3.5f;

    bool hasSked;

    void Awake()
    {
        Player = GetComponent<BasePhysics>();
    }


    private void Update()
    {
        if (Player.Grounded)
        {
            Vector3 newForward = Player.rigidbody.velocity - transform.up * Vector3.Dot(Player.rigidbody.velocity, transform.up);

            if (newForward.magnitude < 0.1f)
            {
                newForward = Model.forward;
            }

            CharRot = Quaternion.LookRotation(newForward, transform.up);
            Model.rotation = Quaternion.Lerp(Model.rotation, CharRot, Time.deltaTime * skinRotationSpeed);

            // CharRot = Quaternion.LookRotation( Player.rigidbody.velocity, transform.up);
            // CharacterAnimator.transform.rotation = Quaternion.Lerp(CharacterAnimator.transform.rotation, CharRot, Time.deltaTime * skinRotationSpeed);
        }
        else
        {
            Vector3 VelocityMod = new Vector3(Player.rigidbody.velocity.x, 0, Player.rigidbody.velocity.z);
            Quaternion CharRot = Quaternion.LookRotation(VelocityMod, -Player.Gravity.normalized);
            Model.rotation = Quaternion.Lerp(Model.rotation, CharRot, Time.deltaTime * skinRotationSpeed);

        }
    }

    void FixedUpdate()
    {
       



        //Skidding

        if (Player.b_normalSpeed < -SkiddingStartPoint && Player.Grounded)
        {
            Player.AddVelocity(Player.rigidbody.velocity.normalized * SkiddingIntensity);
            if (!hasSked && Player.Grounded)
            {
                hasSked = true;
            }
            if (Player.SpeedMagnitude < 4)
            {
                Player.b_normalSpeed = 0;
                hasSked = false;
            }
        }
        else
        {
            hasSked = false;
        }

     


    }

    public void Enter()
    {
        return;
    }

    public void Exit()
    {
        return;
    }
}

