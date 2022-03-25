using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    public static T inst;

    protected void Awake ()
    {
        if(inst == null)
        {
            inst = (T)this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
