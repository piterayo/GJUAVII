using UnityEngine;
using System.Collections;

public class TrapdoorScript : Triggerer {

    public override void ActionA()
    {
        this.GetComponent<Collider2D>().enabled = false;
    }

    public override void ActionB()
    {
        this.GetComponent<Collider2D>().enabled = true;
    }
}
