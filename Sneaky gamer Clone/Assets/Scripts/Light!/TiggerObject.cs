using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerObject : MonoBehaviour
{
    public MiniGameManager manager;
    public GameObject lightObject;
    public GameObject playerObject;

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("player left light");
            lightObject.active = false;
            manager.RequestWin(false);
        }
    }

    public void CleanUp()
    {
        lightObject.SetActive(true);
        playerObject.transform.position = gameObject.transform.position;
    }
}
