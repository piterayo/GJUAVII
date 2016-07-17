using UnityEngine;
using System.Collections;


public enum PowerUp
{
    None, Stone
}

public class Control_Altar : MonoBehaviour
{

    public PowerUp PowerUP;

    public PlayerState PowerUpTransformation;

    public bool used = false;

    public void Use()
    {
        Destroy(this.gameObject);
    }


}
