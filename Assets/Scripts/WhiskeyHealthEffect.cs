using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiskeyHealthEffect : MonoBehaviour
{
    public Scriptable_object_parent healthSpriteGen;
    public Image HealthWhiskey;

    public void healthChange()
    {
        for(int i = 0; i > healthSpriteGen.temphealth; i++)
        {
            HealthWhiskey.enabled = false;
        }
    }
}
