using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    // Color of the node.
    private Material nodeColor;

    // References to Controller
    private GameObject controller;

    private void Start() {
        nodeColor = GetComponent<Renderer>().material;
        controller = GameObject.Find("Controller");
    }

    private void OnMouseOver() {
        // Notify controller that node is being hovered, send location and change color.
        var controllerScript = controller.GetComponent<DrawLine>();
        controllerScript.onNode = true;
        controllerScript.nodePos = transform.position;
        nodeColor.SetColor("_Color", Color.red);
    }

    private void OnMouseExit() {
        // Notify controller that node is being hovered and change color.
        var controllerScript = controller.GetComponent<DrawLine>();
        controller.GetComponent<DrawLine>().onNode = false;
        nodeColor.SetColor("_Color", Color.blue);
    }
}
