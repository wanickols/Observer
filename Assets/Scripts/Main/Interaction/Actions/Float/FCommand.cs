using System.Collections.Generic;
using UnityEngine;

public abstract class FCommand : MonoBehaviour
{
    [SerializeField] protected float value = 0.0f;
    [SerializeField] protected List<Command> commands;
    abstract public void checkVal(float val);

    virtual protected void Perform()
    {
        foreach (var command in commands)
            command.Perform();
    }
}
