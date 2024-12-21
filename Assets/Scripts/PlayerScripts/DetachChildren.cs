using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachChildren : MonoBehaviour
{
    public bool isDead = false, isGhost = true;
    public GameObject childObject;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.childCount != 0)
        {
            childObject = transform.GetChild(0).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* dies */
        GetComponent<MeshRenderer>().enabled = isGhost;
    }

    public void YeetTheChild()
    {
        childObject.GetComponent<BossScript>().ReturnToOrigin();

        childObject = null;

        isGhost = true;
    }

    public void StealTheChild(GameObject gO)
    {
        if (childObject != null)
        {
            childObject.GetComponent<BossScript>().ReturnToOrigin();
        }
        gO.transform.parent = this.gameObject.transform;
        gO.transform.position = this.transform.position;

        childObject = gO;

        GetComponent<PlayerMovement>()._moveSpd = childObject.GetComponent<BossScript>().commonVariables.bossMovSpd;

        isGhost = false;
    }
}
