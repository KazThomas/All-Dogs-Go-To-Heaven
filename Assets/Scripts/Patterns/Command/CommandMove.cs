using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public interface ICommandMove
    {
        void Execute();
        void Undo();
    }

public abstract class CommandMove : MonoBehaviour, ICommandMove
{
    public abstract void Execute();
    public abstract void Undo();
    protected new string name;
    protected Vector3 direction;
    protected Card card;
    protected GameObject target;
}


