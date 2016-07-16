using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BezierCurve))]

public class ScriptedPath : MonoBehaviour
{

    private bool forward;

    private bool loop;

    private Transform target;

    public Transform Target
    {
        set
        {
            if (!active)
            {
                target = value;
                targetComponents = null;
            }
        }
        get
        {
            return target;
        }
    }

    public bool isForward
    {
        get { return forward; }
    }

    public bool Loop
    {
        set { loop = value; }
        get { return loop; }
    }

    public bool AtEnd
    {
        get { return !forward && !active; }
    }

    public bool AtStart
    {
        get { return forward && !active; }
    }

    public float time;

    private bool active;

    private float speed;

    private float percent;

    private BezierCurve curve;

    private MonoBehaviour[] targetComponents;

    // Use this for initialization
    void Start()
    {
        curve = GetComponent<BezierCurve>();
        active = false;
        forward = true;
        percent = 0.0f;
        speed = 1 / time;
    }

    // Update is called once per frame
    void Update()
    {
        if (active && target != null)
        {
            if ((curve.pointCount > 1))
            {
                if (forward && (percent < 1.0f))
                {
                    percent += speed * Time.deltaTime;

                    if (percent > 1) percent = 1;

                    target.position = curve.GetPointAt(percent);
                }
                else if (forward && (percent >= 1.0f))
                {
                    forward = false;
                    if (!loop)
                    {
                        active = false;
                    }
                }
                else if (!forward && (percent > 0.0f))
                {
                    percent -= speed * Time.deltaTime;

                    if (percent < 0) percent = 0;

                    target.position = curve.GetPointAt(percent);
                }
                else if (!forward && (percent <= 0))
                {
                    forward = true;
                    if (!loop)
                    {
                        active = false;
                    }
                }
            }
        }
    }

    public void Reverse()
    {
        forward =! forward;
    }

    public void FreeTarget()
    {
        if (target != null)
        {
            Rigidbody2D rigid = target.GetComponent<Rigidbody2D>();
            if (rigid != null)
            {
                rigid.isKinematic = false;
            }

            if (targetComponents != null)
            {
                foreach (MonoBehaviour c in targetComponents)
                {
                     c.enabled = true;
                }
            }
            targetComponents = null;
            target = null;


            active = false;
            forward = true;
            percent = 0.0f;
        }
    }

    public void ContinuePath()
    {
        active = true;
    }

    public void PausePath()
    {
        active = false;
    }

    public void StartPath()
    {
        Rigidbody2D rigid=target.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            rigid.isKinematic = true;
            rigid.velocity = new Vector2(0f, 0f);
            rigid.angularVelocity = 0f;
        }
        getTargetComponents();
        foreach (MonoBehaviour c in targetComponents)
        {
                c.enabled = false;
        }
        percent = 0.0f;
        active = true;
    }

    private void getTargetComponents()
    {
        if (target != null)
        {
            targetComponents = target.GetComponents<MonoBehaviour>();
        }
    }

}
