using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float parralaxingAmountX;
    [SerializeField] private float parralaxingAmountY;

    private Vector3 initialObjectPos;

    private void Start()
    {
        initialObjectPos = transform.position;
    }

    void Update()
    {
        Vector3 cameraPos = cameraTransform.position;
        transform.position = new Vector3(initialObjectPos.x + cameraPos.x * parralaxingAmountX, initialObjectPos.y + cameraPos.y * parralaxingAmountY, initialObjectPos.z);
    }
}
