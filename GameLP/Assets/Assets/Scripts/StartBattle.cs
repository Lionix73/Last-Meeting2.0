using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour
{ 

}
   /*  private enum State
    {
        Idle,
        Active,
        BattleOver,
    }

    [SerializeField] private ColliderTrigger colliderTrigger;
    [SerializeField] private Wave[] waveArray;

    private State state;

    private void Awake()
    {
        state = State.Idle;
    }

    private void Start()
    {
        colliderTrigger.OnPlayerEntertrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {

        if (state == State.Idle)
        {
            StartBattle();
            colliderTrigger.OnPlayerEntertrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }

    }

    private void StartBattle()
    {
        state = State.Active;

        wave.SpawnEnemies();
    }

    private void Update()
    {
        switch (state)
        { 
        foreach (Wave wave in waveArray
        {
            wave.Update();
        }

        TestBattleOver();
        break;
        }
    }

}

private void TestBattleOver()
{
    if (state == State.Active)
    {
        if (AreWavesOver())
        {
            //Battle is over
            state = State.BattleOver;
            Debug.Log("Battle Over");
        }
    }
}

private bool AreWavesOver()
{
    foreach (Wave wave in waveArray
    {
        if (wave.IsWaveOver())
        {
            //Wave is Over
        }
        else
        {
            return false;
        }

        return true;
    }
    break;
}

[System.Serializable]
private class Wave
{
    [SerializeField] private EnemySpawn[] enemySpawnArray;
    [SerializeField] private float timer;

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                SpawnEnemies();
            }
        }
    }

    private void SpawnEnemies()
    {
        foreach (EnemySpawn enemySpawn in enemySpawnArray)
        {
            enemySpawn.Spawn();
        }
    }
}

public bool IsWaveOver()
{
    if (timer < 0)
    {
        foreach (EnemySpawn enemySpawn in enemySpawnArray)
        {
            if (enemySpawn.IsAlive())
            {
                return false;
            }
        }
        retunr true;
    }
    else
    {
        return false;
    }
}
} */
