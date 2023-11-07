using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform exitPoint;

    public int exitRotation;
    
    void Awake()
    {
        exitRotation = exitRotation + (int)transform.eulerAngles.y;
        Debug.Log(this + " exit rotation is now " + exitRotation);
    }
}
