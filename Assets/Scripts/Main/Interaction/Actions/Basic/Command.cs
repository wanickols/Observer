using UnityEngine;

public abstract class Command : MonoBehaviour
{
    protected bool HasInteracted = false;
    abstract public void Perform();

    virtual public void Undo() { }
    virtual public void Reset() { }
}
