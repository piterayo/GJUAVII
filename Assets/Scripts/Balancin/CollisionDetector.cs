using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        //transform.parent.GetComponent<Balancin>().ReceiveCollision(other.transform.GetComponent<Rigidbody2D>());
    }

}
