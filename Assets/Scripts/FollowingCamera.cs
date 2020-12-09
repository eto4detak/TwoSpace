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


    private void FixedUpdate()
    {
        if (target)
        {
            FollowingDistance();
        }
    }


    private void Following()
    {
        Vector3 newPosition = target.transform.position;
        newPosition.y = startPosition.y;
        transform.position = target.transform.position + targetOffset;
    }

    private void FollowingDistance()
    {
        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        float maxDistance = 10;

        //Vector3 needPosition = target.transform.position + targetOffset;
        //needPosition = needPosition.normalized * Time.deltaTime;
        //needPosition.y = startPosition.y;

        //transform.position = target.transform.position + targetOffset;
        //if (distanceToTarget > maxDistance)
        //{
        //    transform.position = target.transform.position + targetOffset;
        //}


            Vector3 direction = target.transform.position + targetOffset - transform.position;

            transform.Translate(direction * Time.deltaTime, Space.World);

    }

}
