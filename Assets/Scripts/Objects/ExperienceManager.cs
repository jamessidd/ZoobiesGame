using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{

    public static ExperienceManager Instance;

    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    // Singleton Check
    private void Awake()
    {

        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        
        else

        {
            Instance = this;
        }

    }


    public void AddExperience(int amount)
    {

        OnExperienceChange?.Invoke(amount);

    }
}
