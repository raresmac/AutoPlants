using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMoveCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameManager gameManager;
    public void moveCamera()
    {
        mainCamera.transform.position = new Vector3(2.52f, -1.48f, -3.76f);
        gameManager.InstantiateUnits();
        Destroy(gameObject);
    }
}
