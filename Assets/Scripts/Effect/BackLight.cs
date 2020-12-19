using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLight : MonoBehaviour
{
    public GameObject sourse;
    private ParticleSystem[] backLight;
    private Health owner;
    private void Awake()
    {
        backLight = sourse.GetComponentsInChildren<ParticleSystem>();
        owner = GetComponent<Health>();
        owner.EventDie.AddListener(OnDie);
    }

    void Start()
    {
        SetColor();
    }

    private void OnDie()
    {
        Destroy(sourse, 1f);
    }

    private void SetColor()
    {
        if (owner == null || backLight == null) return;
    }
}
