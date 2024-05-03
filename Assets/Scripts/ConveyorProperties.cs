using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConveyorProperties : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    public int topEdgeYPosition = 5;
    public int bottomEdgeYPosition = -8;
    public float speed = 1f;
    public int size = 1;
}
