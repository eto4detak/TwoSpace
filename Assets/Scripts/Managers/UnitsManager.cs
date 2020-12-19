using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UnitsManager : Singleton<UnitsManager>
{
    [System.Serializable]
    public struct TeamColor
    {
        public Team team;
        public Material color;
    }

    public Unit unitPrefab;
    public Ship hero;
    public Ship forvard;
    public Ship stalker;

    public List<Unit> enemies;
    public List<Unit> units = new List<Unit>();
    public UnityEvent dieHero = new UnityEvent();

    public List<Locality> localities = new List<Locality>();
    //public List<GameUnit> units = new List<GameUnit>();
    public UnityEvent EventPlayerDead = new UnityEvent();
    public UnityEvent EvennEnemyDead = new UnityEvent();



    //public List<PlayerBaseUI> playerPanels = new List<PlayerBaseUI>();

    public void Start()
    {
        AddBonusStalker();
    }

    public void AddBonusStalker()
    {
        float bonus = 1f;
        stalker.SetBonusSpeed(bonus);
    }



    public List<Locality> GetClosestLocalities(GameObject from)
    {
        List<Locality> locs = new List<Locality>(localities);
        Locality temp;
        for (int j = 0; j < locs.Count; j++)
        {
            float dist1 = Vector3.Distance(from.transform.position, locs[j].transform.position);
            for (int i = 0; i < locs.Count; i++)
            {
                if (locs[j] == locs[i]) continue;

                float dist2 = Vector3.Distance(from.transform.position, locs[i].transform.position);
                if (dist1 < dist2)
                {
                    temp = locs[j];
                    locs[j] = locs[i];
                    locs[i] = temp;
                }
            }
        }

        return locs;
    }

    public Team GetNewTeam()
    {
        Team found = Team.Neitral;
        for (int i = 0; i < localities.Count; i++)
        {
            if ((localities[i].team) > found)
            {
                found = localities[i].team;
            }
        }
        return found + 1;
    }

    protected void TryChangeTeam()
    {
        int minUnit = 50;
        Team noTeam = Team.Neitral;
        if (GameTime.instance.timeDay == TimeDay.Day)
        {
            for (int i = 0; i < localities.Count; i++)
            {
                if (localities[i].team == noTeam &&
                     localities[i].people.humans.Count > minUnit)
                {
                    localities[i].ChangeTeam(GetNewTeam());
                }
            }
        }
    }

    public void Registration(GameUnit add)
    {
        //List<Unit> stack = GetCommandStack(unit.GetTeam());
        //if (!stack.Exists(x => x.Equals(unit)))
        //{
        //    stack.Add(unit);

        //}
        //unit.die.RemoveListener(RemoveUnit);
        //unit.die.AddListener(RemoveUnit);
    }

    public Health GetClosestEnemy(Health origin)
    {
        Unit closest = null;
        //float closestDistanceSqr = Mathf.Infinity;
        //Vector3 directionToTarget;
        //List<Unit> enemies = GetEnemyStack(origin.GetTeam());
        //for (int i = 0; i < enemies.Count; i++)
        //{
        //    directionToTarget = enemies[i].transform.position - origin.transform.position;
        //    float dSqrToTarget = directionToTarget.sqrMagnitude;
        //    if (dSqrToTarget < closestDistanceSqr)
        //    {
        //        closestDistanceSqr = dSqrToTarget;
        //        closest = enemies[i];
        //    }
        //}
        return closest.health;
    }

    public void AttachedUnit(Unit added)
    {
        KeyController keyC = added.GetComponent<KeyController>();
        //if (keyC)
        //{
        //    hero = added;
        //}

        bool newUnit = !units.Exists(x => x.Equals(added));
        if (newUnit)
        {
            units.Add(added);
        }
    }

    public void RemoveUnit(Unit removed)
    {
        units.Remove(removed);
    }


    public void AddUnit(Unit added)
    {
        units.Add(added);
        //PlayerBaseUI emptyPanel = playerPanels.Find(x => x.origin == null);
        //if (emptyPanel != null)
        //{
        //    emptyPanel.Setup(added);
        //}
    }


    public static List<T> FindObjectsOfTypeAll<T>()
    {
        List<T> results = new List<T>();
        SceneManager.GetActiveScene().GetRootGameObjects().ToList().ForEach(g => results.AddRange(g.GetComponentsInChildren<T>()));
        return results;
    }



    public void StopUnit()
    {
        for (int i = 0; i < units.Count; i++)
        {
            units[i].enabled = false;
        }
        for (int i = 0; i < units.Count; i++)
        {
            AIAttacker ai = units[i].GetComponent<AIAttacker>();
            if (ai) ai.target = null;
        }
    }

    public void StartUnits()
    {
        for (int i = 0; i < units.Count; i++)
        {
            units[i].enabled = true;
        }

        //for (int i = 0; i < units.Count; i++)
        //{
        //    AIMag ai = units[i].GetComponent<AIMag>();
        //    if (ai) ai.enabled = true;

        //    KeyController keyC = units[i].GetComponent<KeyController>();
        //    if (keyC) keyC.enabled = true;
        //}

    }

    public void SetVitoryEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            //enemies[i].ChangeState(UnitState.Victory);
        }
    }


}
