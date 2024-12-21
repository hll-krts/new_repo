using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<PlayerMovement>().MinionHit();
        }
    }
}
