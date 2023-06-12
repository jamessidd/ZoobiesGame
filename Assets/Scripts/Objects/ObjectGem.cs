using UnityEngine;
using System.Collections;


public class ObjectGem : MonoBehaviour
{

    [Header("Rotation Values")]
    public Vector3 RotateSpeed;
    public float InitialRandomRotationAmm;
    public bool SetBasedOnXpos = true;
    [Header("Magnetization Values")]

    public Transform player;
    public float detectionRadius = 8f;
    public float lerpSpeed = 0.8f;


    [Header("Other Values")]
    public int expAmount;
    private float disappearTime = 35f; // set the time you want the object to disappear



    void Start()
    {
        Vector3 rand = new Vector3(0, Random.Range(0, InitialRandomRotationAmm), 0);
        transform.Rotate(rand);
        if (SetBasedOnXpos)
        {
            Vector3 set = new Vector3(0, transform.position.x + transform.position.z, 0);
            transform.Rotate(set);
        }
    }

    void Update()
    {
        transform.Rotate(RotateSpeed * Time.deltaTime);

        if (Vector3.Distance(player.position, transform.position) <= detectionRadius)
        {
            
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z); //create new target position that has player's x and z but keeps object's y

            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime); //lerp pos of object towards player
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            ExperienceManager.Instance.AddExperience(expAmount);

            //start the disappear coroutine
            StartCoroutine(Disappear());
        }
    }

    IEnumerator Disappear()
    {
        //make  gem disappear
        gameObject.SetActive(false);

        //wait
        yield return new WaitForSeconds(disappearTime);

        //make gem reappear
        gameObject.SetActive(true);
    }
}



