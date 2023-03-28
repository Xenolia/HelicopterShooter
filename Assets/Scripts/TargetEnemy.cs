using UnityEngine;
using System.Collections;

public class TargetEnemy : MonoBehaviour {

	float randomTime;
	bool routineStarted = false;

	//Used to check if the target has been hit
	public bool isHit = false;

	public AudioSource audioSource;
    Animator Anim;
    int randomDeath;

    public void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    private void Update () {
		
		//Generate random time based on min and max time values
		

		//If the target is hit
		if (isHit == true) 
		{
            randomDeath = Random.Range(1, 5);
            Anim.SetBool("Death"+randomDeath, true);
            StartCoroutine(DelayTimer());
            // Destroy(gameObject);
            isHit = false;


		}
	}

	//Time before the target pops back up
	private IEnumerator DelayTimer () {
		//Wait for random amount of time
		yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
		
	}
}