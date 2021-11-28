using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton: MonoBehaviour
{
    public static Singleton Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        Instance = this;
    }

}
