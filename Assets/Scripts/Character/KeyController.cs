using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : Singleton<KeyController>
{
    public Ship controlled;

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(direction.sqrMagnitude != 0)
        {
            controlled.Navigate(ref direction);
        }
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    controlled.ApplySpell(new FireBallSpell());
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    controlled.ApplySpell(new TeleportSpell());
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    controlled.ApplySpell(new ElectroSpell());
        //}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    controlled.ApplySpell(new BombSpell());
        //}
        //if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine( controlled.WantJump());
        //}
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    controlled.ApplySpell(new RainSpell());
        //}
        //if (Input.GetKeyDown(KeyCode.V) )
        //{
        //    controlled.ApplySpell(new Dispell());
        //}
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    controlled.ApplySpell(new SwordSpell());
        //}
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    controlled.ApplySpell(new PhobiaBallSpell());
        //}
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    controlled.ApplySpell(new MagicShieldSpell());
        //}

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    controlled.ApplySpell(new FrozenBallSpell());
        //}
    }
}

