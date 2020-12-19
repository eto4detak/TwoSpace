using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public CharacterContrMovement movement;
    public float shipSpeed = 60f;
    public float currentSpeed;
    public float currnetHealth;
    public float maxHealth;

    private Vector3 navigate;
    private float bonusSpeed;

    public void Awake()
    {
        currentSpeed = shipSpeed + bonusSpeed;
    }

    void Update()
    {
        Fly();
    }

    public void Navigate(ref Vector3 direct)
    {
        navigate = direct;
    }

    public void TakeDamage(float damage)
    {
        currnetHealth -= damage;
        if (currnetHealth <= 0)
        {
            currnetHealth = 0;
        }
    }


    public void SetBonusSpeed(float bonus)
    {
        bonusSpeed = bonus;
        currentSpeed = shipSpeed + bonusSpeed;
    }


    ////3d
    //private void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log(other.gameObject.name + " Enter " + " speed= " + other.relativeVelocity + "   impulse= " + other.impulse);
    //    Boom();
    //}

    //private void OnCollisionExit(Collision other)
    //{
    //    Debug.Log(other.gameObject.name + "Exit " + "speed= " + other.relativeVelocity + "   impulse= " + other.impulse);
    //}
    //private void OnCollisionStay(Collision other)
    //{
    //    Debug.Log(other.gameObject.name + "Stay " + "speed= " + other.relativeVelocity + "   impulse= " + other.impulse);
    //}

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(1);
        Debug.Log("health " + currnetHealth);
    }


    public void Crash()
    {
        Debug.Log("Charsh " + name);
        Destroy(gameObject);

    }


    public void Fly()
    {
        Vector3 offset = (transform.forward * currentSpeed + new Vector3(navigate.y, navigate.z, -navigate.x)) * Time.deltaTime;
        transform.position += offset;

        float rotateSpeed = 30f;
        transform.Rotate(new Vector3(-navigate.z, navigate.x, navigate.y) * rotateSpeed * Time.deltaTime);
    }


}
