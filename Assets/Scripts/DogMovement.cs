using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] private Vector3 pos;
    [SerializeField] private int movement;

    public void SetMovement(int movement)
    {
        this.movement = movement;
    }

    public int GetMovement()
    {
        return movement;
    }

    public Vector3 GetPosition()
    {
        return pos;
    }

    public void SetPos(Vector3 vec3)
    {
        pos = vec3;
    }
}
