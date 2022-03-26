using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Portal")
        {
            this.gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
    }
}
