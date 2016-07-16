using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Spawned))]

public class DetectDeath : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Death")
        {
            this.GetComponent<Spawned>().Die();
        }
    }

}
