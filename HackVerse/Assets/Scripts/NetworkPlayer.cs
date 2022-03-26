using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{
    public Transform avatar;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");

        if (photonView.IsMine)

        {
            int totalCount = avatar.transform.childCount;

            for (int i = 0; i<totalCount; i++)
            {
                avatar.transform.GetChild(i).gameObject.SetActive(false);
            }

          
        }

            

    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            avatar.gameObject.SetActive(true);
            
            

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Portal")
        {
            this.gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Portal")
        {
            this.gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
