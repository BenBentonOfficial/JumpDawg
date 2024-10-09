using System;
using TMPro;
using UnityEngine;

public class StateCheck : MonoBehaviour
{
    private TextMeshPro text;
    private PlayerStateMachine _stateMachine;
    [SerializeField] private GameObject target;

    private void Awake()
    {
        _stateMachine = target.GetComponent<PlayerStateMachine>();
        text = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        _stateMachine.StateChange += UpdateText;
    }

    private void Update()
    {
        transform.position = target.transform.position + (Vector3.up * 1);
    }

    private void UpdateText(State<PlayerStateMachine.EPlayerState> state)
    {
        text.text = state.StateKey.ToString();
    }
    
}
