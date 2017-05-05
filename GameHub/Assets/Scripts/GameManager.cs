using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region Public attributes
    [Tooltip("Optional. If empty, will try to find a standard name.")]
    public GameObject ipListText;


    [Tooltip("Will be used if the Ip List Text is not assigned.")]
    public string ipListTextDefaultName = "IPs List";
    #endregion


    // Use this for initialization
    void Start () {
        this.setIpListText();


        ipListText.GetComponent<Text>().text = "<b>Try to connect to one of this IPs</b>\n\n";

        IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

        int count = 0;
        foreach (var ip in localIPs) {
            if (count != 0) {
                ipListText.GetComponent<Text>().text += "\n";
            }
            ipListText.GetComponent<Text>().text += ip;
            count++;
        }
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void setIpListText() {
        if (this.ipListText == null) {
            this.ipListText = GameObject.Find(this.ipListTextDefaultName);
        }

        if (this.ipListText == null) {
            throw new UnityException("Could not find ipListText.");
        }
    }
}
