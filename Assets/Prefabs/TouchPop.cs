using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPop : MonoBehaviour
{
    public Camera arCamera;
    public RandomSpawner spawner;

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        Ray ray = arCamera.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Destroy(hit.transform.gameObject);
            spawner.UpdateScore();
            return;
        }
    }
}
