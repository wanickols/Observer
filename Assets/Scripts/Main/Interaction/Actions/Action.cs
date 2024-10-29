using UnityEngine;

public abstract class Action : MonoBehaviour
{
    protected bool HasInteracted = false;
    abstract public void Perform();

    virtual public void Reset() { }
}
