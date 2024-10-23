using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atachable : MonoBehaviour
{
    [SerializeField] private bool _isAtachable;
    private bool _isAtached;

    public bool IsAtachable
    {
        get { return _isAtachable; }
        set { _isAtachable = value; }
    }

    public bool IsAtached
    {
        get { return _isAtached; }
        set { _isAtached = value; }
    }
}
