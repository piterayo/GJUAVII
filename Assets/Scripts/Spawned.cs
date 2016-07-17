using UnityEngine;
using System.Collections;

public class Spawned : MonoBehaviour {

    public Spawner spawner;

    public void Die()
    {
        if (transform.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(Resources.Load("Prefabs/DeadBody"));
            GameObject.Find("levelManager").GetComponent<levelManager>();
        }
        else
        {
            spawner.Spawn();
        }
    }

}
