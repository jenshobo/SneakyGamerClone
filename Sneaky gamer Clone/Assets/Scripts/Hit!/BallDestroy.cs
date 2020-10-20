using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
}
