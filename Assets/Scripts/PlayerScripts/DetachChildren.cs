using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachChildren : MonoBehaviour
{
    public bool isDead = false, isGhost = true;
    public GameObject childObject, ghostSprite;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.childCount <= 1)
        {
            childObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* dies */
        ghostSprite.SetActive(isGhost);
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
            YeetTheChild();
        }
        gO.transform.parent = this.gameObject.transform;
        gO.transform.position = this.transform.position;

        childObject = gO;

        GetComponent<PlayerMovement>()._moveSpd = childObject.GetComponent<BossScript>().commonVariables.bossMovSpd;

        isGhost = false;
    }
}
