﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTactics : IAITactics
{
    public Ship owner;

    public AttackTactics()
    {
    }

    public void Control()
    {
        //float maxOffset = 1f;
        //Vector3 toTarget = owner.target.transform.position - owner.transform.position;
        //Vector3 forvard = owner.transform.forward * toTarget.magnitude;
        //float delta = (forvard - toTarget).magnitude;
        //if(delta < maxOffset) owner.ApplyAttackSpell();
    }

    public float GetPriority()
    {
        float val = 1f;

        return val;
    }

}
