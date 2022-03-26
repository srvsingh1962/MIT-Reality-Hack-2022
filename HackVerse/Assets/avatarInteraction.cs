using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Portal")
        {
            this.gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
    }
}
