using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class SDKLANG : MonoBehaviour {
    public Text deviceText;
    
    [DllImport("__Internal")] private static extern void ProjectStarted();

    public void GettingDevice(string _device)
    {
        //var json = JSON.Parse(_device);
        //string device = json["type"];
        //deviceText.text = device;
    }
}
