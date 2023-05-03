using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeControl : MonoBehaviour
{
    public static Animator[] gnomeAnimators;

    private void Start()
    {
        gnomeAnimators = GetComponentsInChildren<Animator>();
    }

    public static void ActivateAnimationBool(string name)
    {
        foreach(AnimatorControllerParameter parameter in gnomeAnimators[0].parameters)
        {
            for(int i = 0; i < gnomeAnimators.Length; i++)
            {
                gnomeAnimators[i].SetBool(parameter.name, false);
            }
        }

        foreach(Animator anim in gnomeAnimators)
        {
            anim.SetBool(name, true);
        }
        
    }
}
