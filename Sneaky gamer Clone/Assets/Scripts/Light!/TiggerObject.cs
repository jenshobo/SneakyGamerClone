using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerObject : MonoBehaviour
{
    public bool playerInSphere = true;

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerInSphere = false;
        }
    }
}
