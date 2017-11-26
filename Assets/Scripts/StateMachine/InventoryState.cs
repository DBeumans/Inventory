using UnityEngine;
using System.Collections;

public abstract class InventoryState : MonoBehaviour
{

    public virtual void Enter()
    {
    }

    public virtual void Leave()
    {
    }

    public abstract void Act();
}
