using UnityEngine;
using System.Collections;


public class PlayerState : MonoBehaviour
{

    private PowerUp pu = PowerUp.None;

    private PlayerState transformation;



    public PlayerState Transformation
    {
        set { transformation = value; }
    }

    public PowerUp CurrentPower
    {
        get { return pu; }
        set { pu = value; }
    }

    void Update()
    {
        if (Input.GetButtonDown("Skill" + transform.name))
        {
            if (pu != PowerUp.None)
            {
                if (transformation != null)
                {
                    PlayerState go = Instantiate(transformation);
                    go.name = transform.name;
                    go.transformation = this;
                    go.transform.position = this.transform.position;
                    this.gameObject.SetActive(false);
                }
            }
            else
            {
                if (transformation != null)
                {
                    transformation.gameObject.SetActive(true);
                    transformation.transform.position = transform.position+new Vector3(0,1,0);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
