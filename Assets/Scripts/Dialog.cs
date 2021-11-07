using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{   
    public string char_name;

    [TextArea(3,5)]
    public string[] kalimat_kalimat;
}
