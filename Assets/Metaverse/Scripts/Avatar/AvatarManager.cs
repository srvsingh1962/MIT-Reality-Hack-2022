using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class AvatarManager : MonoBehaviourPunCallbacks, IHoverable
{
    public GameObject[] hats;
    public GameObject[] faces;
    public GameObject[] torsos;
    public GameObject head;
    public GameObject torso;
    float hatindex;
    float torsoindex;
    float faceindex;
    public string playerpronouns;
    public string playerrole;
    public string stack;
    public string about;


    public TMP_Text username;
    public TMP_Text role;
    public TMP_Dropdown filterdropdown;
    public GameObject infoPanel;
    public TMP_Text infoPanelText;

    public GameObject smileyhead;

    public GameObject filterPanel;
    public bool IsSelected => throw new System.NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        InitialiseAvatar();
 

    }

    public void InitialiseAvatar()
    {
      //  R = (float)photonView.Owner.CustomProperties["R"];
        //G = (float)photonView.Owner.CustomProperties["G"];
        //B = (float)photonView.Owner.CustomProperties["B"];
        hatindex = (float)photonView.Owner.CustomProperties["hat"];
        torsoindex= (float)photonView.Owner.CustomProperties["torso"];
        faceindex = (float)photonView.Owner.CustomProperties["face"];
        playerpronouns = (string)photonView.Owner.CustomProperties["pronouns"];
        playerrole = (string)photonView.Owner.CustomProperties["role"];
        stack = (string)photonView.Owner.CustomProperties["stack"];
        about = (string)photonView.Owner.CustomProperties["about"];

        username.text = photonView.Owner.NickName+" ("+ playerpronouns+")";
        role.text = "("+playerrole+")";

        SetHat(hatindex);
    }
    
    public void InfoAssigner(string name,string stack,string about,bool state)
    {
        infoPanel.SetActive(state);
        if (state)
        {
            infoPanelText.text = "You are looking at " + name + "\n" + name + "'s Techstack is " + stack + "\n" + "About " + photonView.Owner.NickName + " :" + about;
        }
        
         

    }
    public void SetHat(float hatindex)
    {
        
        for (int i=0;i<hats.Length;i++)
        {
           if(i==hatindex)
            {
                hats[i].SetActive(true);
            }
           else
            {
                hats[i].SetActive(false);
            }
        }
         for (int i = 0; i < faces.Length; i++)
        {
            if (i == faceindex)
            {
                faces[i].SetActive(true);
            }
            else
            {
                faces[i].SetActive(false);
            }
        }
        for (int i = 0; i < torsos.Length; i++)
        {
            if (i == torsoindex)
            {
                torsos[i].SetActive(true);
            }
            else
            {
                torsos[i].SetActive(false);
            }
        }
    }
    public void OnGazeEnter(GazeData data)
    {
        print("you are looking at " + this.gameObject.name);

        if (looker != null)
        {
            looker.GetComponent<AvatarManager>().InfoAssigner(photonView.Owner.NickName, stack, about, true);
        }
    }

    public GameObject[] allplayers;
    public void SetFilter(int value)
    {
         allplayers = GameObject.FindGameObjectsWithTag("User");
       foreach(GameObject user in allplayers)
        {
            
                string a = filterdropdown.options[value].text;
                string b = user.GetComponent<PlayerController>().avatarmanager.playerrole;
                if (a.CompareTo(b) != 0)

                {
                    user.GetComponent<PlayerController>().avatarmanager.username.gameObject.SetActive(false);
                    user.GetComponent<PlayerController>().avatarmanager.role.gameObject.SetActive(false);
                }
                else
                {
                    user.GetComponent<PlayerController>().avatarmanager.username.gameObject.SetActive(true);
                    user.GetComponent<PlayerController>().avatarmanager.role.gameObject.SetActive(true);
                }
            

        }
    }
    public void OnGazeExit(GazeData data)
    {
        if (looker != null)
        {

            looker.GetComponent<AvatarManager>().InfoAssigner(photonView.Owner.NickName, stack, about, false);
            looker = null;
        }
    }

    public void OnClick(GazeData data)
    {
        print("you said hi");

    }

    public GameObject looker;
     public void SetLooker(GameObject gameObject)
    {
        looker = gameObject;
    }
}
