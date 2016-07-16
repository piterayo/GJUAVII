using UnityEngine;
using System.Collections;

public class Spawned : MonoBehaviour {

    public Spawner spawner;

    public void Die()
    {
        spawner.Spawn();
    }

}
