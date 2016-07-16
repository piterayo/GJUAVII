using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Spawned objectType=null;

    private Spawned target = null;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (objectType != null)
        {
            if (target != null)
            {
                GameObject.Destroy(target.gameObject);
            }
            target = Instantiate(objectType);
            target.transform.position = this.transform.position;
            target.spawner = this;
        }
    }
}
