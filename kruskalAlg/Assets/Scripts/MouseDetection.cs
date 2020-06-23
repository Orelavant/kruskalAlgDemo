using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    public bool onNode;
    private Material nodeColor;

    private void Start() {
        nodeColor = GetComponent<Renderer>().material;
    }

    private void OnMouseOver() {
        onNode = true;
        nodeColor.SetColor("_Color", Color.red);
    }

    private void OnMouseExit() {
        onNode = false;
        nodeColor.SetColor("_Color", Color.blue);
    }
}
