using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] Health _player = null;

    public AudioSource Monkey = null;

    public Creature _health = null;

    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] GameObject PlayerDamage = null;

    public override void Enter()
    {

        Monkey.Play();
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy swipes at the player for 3 damage");
        _player.TakeDamage(3);
        EnemyTurnEnded?.Invoke();

        StateMachine.ChangeState<PlayerTurnCardGameState>();
    }


}
