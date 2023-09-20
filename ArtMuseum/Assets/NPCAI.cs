using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    public Transform castPoint;

    float distance = 20f;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        distance = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (rayCastLOS(distance))
        {
            moveNPC();
        }
        else
        {
            stopNPC();
        }
    }

    bool rayCastLOS(float distance)
    {
        bool returnCase = false;
        float castDist = distance;

        Vector3 endPos = castPoint.position + Vector3.right * castDist;
       RaycastHit hit;
        if (Physics.Linecast(castPoint.position, endPos, out hit, 1 << LayerMask.NameToLayer("Action")))
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    returnCase = true;
                }
                else
                {
                    returnCase = false;
                }
                
            }
            else
            {
                Debug.DrawLine(castPoint.position, endPos, Color.blue);
            }
        }

        

        
        return returnCase;
    }

    void moveNPC()
    {
        rb.velocity = new Vector3(2, 2, 2);
    }
    void stopNPC()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
}
