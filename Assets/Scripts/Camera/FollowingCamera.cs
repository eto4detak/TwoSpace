using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject target;

    private Vector3 startPosition;
    private Vector3 targetOffset;

    private void Awake()
    {
        startPosition = transform.position;
        if (target)
        {
            targetOffset = transform.position - target.transform.position;
        }
        else
        {
            targetOffset = transform.position;
        }
    }


    private void Update()
    {
        FollowingRotate();
    }


    private void Following()
    {
        Vector3 newPosition = target.transform.position;
        newPosition.y = startPosition.y;
        transform.position = target.transform.position + targetOffset;
    }

    private void FollowingDistance()
    {
        Vector3 offset = (target.transform.position + targetOffset - transform.position) * Time.deltaTime;
        transform.Translate(offset , Space.World);
    }



    private void FollowingRotate()
    {
        float speedCamera = 4f;
        float lenght = -10f;
        float up = 3;

        Vector3 offset = (target.transform.position + target.transform.forward * lenght + target.transform.up * up - transform.position) * Time.deltaTime * speedCamera;

        transform.Translate(offset, Space.World);
        transform.LookAt(target.transform, target.transform.up);
        //transform.rotation = target.transform.rotation;
    }
}
