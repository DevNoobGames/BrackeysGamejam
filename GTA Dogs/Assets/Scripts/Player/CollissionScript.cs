using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollissionScript : MonoBehaviour
{
    public AudioSource HitLoSAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LineOfSight"))
        {
            other.GetComponentInParent<EnemyChaser>().enabled = true;
            HitLoSAudio.Play();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("WeightCheck"))
        {
            if (GetComponent<PlayerStats>().PartsFound >= other.GetComponent<WeightCheck>().weightRequired)
            {
                foreach (Animator Anima in other.GetComponent<WeightCheck>().Anim)
                {
                    Anima.enabled = true;
                }
                //other.GetComponent<WeightCheck>().Anim.enabled = true;
                Destroy(other.gameObject);
            }
        }
    }
}
