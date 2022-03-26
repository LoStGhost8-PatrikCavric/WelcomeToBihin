using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog 
{
    //it's basically a type, allows you to define a name, number of lines and the content of those lines
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;


}
