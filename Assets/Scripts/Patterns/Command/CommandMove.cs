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
    protected Movement dogMove;
    protected Card card;
    protected GameObject target;
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    public void MoveTarget(GameObject target)
    {
            this.target = target;
    }
    public string GetName()
            { return name; }
    } 

