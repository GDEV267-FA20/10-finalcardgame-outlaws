using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintTestScript : MonoBehaviour
{
    public Copperplate copperplate;
    public Sally sally;
    public Sabrina sabrina;
    public William william;
    #region printlines
    public void printStatement()
    {
        print(copperplate.name);
    }

    public void printStatement2()
    {
        print(sabrina.name);
    }

    public void printStatement3()
    {
        print(sally.name);
    }

    public void printStatement4()
    {
        print(william.name);
    }
    #endregion


}
