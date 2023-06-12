using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelManager : MonoBehaviour
{

    [HideInInspector] public float currentExp;
    public float currentLevel, ExpToLevelUp;
    [HideInInspector] public float topSpeed, maxSpeed = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        InitLevel();
    }

    private void OnEnable()
    {
        //subscribe to event
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    }

    private void OnDisable()
    {
        //unsubscribe
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }


    private void HandleExperienceChange(int newExperience)
    {
        currentExp += newExperience;

        if(currentExp >= ExpToLevelUp)
        {
            LevelUp();

        }
    }

    private void InitLevel()
    {
        maxSpeed = 2 * currentLevel + 35;
        topSpeed = 2 * currentLevel + 15;
    }

    private void LevelUp()
    {
        currentLevel++;

        maxSpeed = 2 * currentLevel + 35;
        topSpeed = 2 * currentLevel + 15;

        currentExp = 0;
        ExpToLevelUp += 100;

    }

}
