using UnityEngine;
using System.Collections;

public class Spawned : MonoBehaviour {

    public Spawner spawner;

    public void Die()
    {
        if (transform.tag == "Player")
        {
            GameObject dead = Instantiate(Resources.Load("Prefabs/DeadBody")) as GameObject;
            dead.transform.position = this.transform.position;
            Destroy(this.gameObject);
            GameObject.Find("levelController").GetComponent<levelManager>().startRestartTimer();
        }
        else
        {
            spawner.Spawn();
        }
    }

}
