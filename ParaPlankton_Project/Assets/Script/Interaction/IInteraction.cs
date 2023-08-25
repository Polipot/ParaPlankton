using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IInteraction : MonoBehaviour
{
    /// <summary>
    /// Called when the player interacts with the object
    /// </summary>
    public virtual void Interaction() 
    {
        Debug.Log("Interaction");
    }
}
