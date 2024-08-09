using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyReferences : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator stateMachine;

    [HideInInspector] public FieldOfView fov;

    [Header("Movement")]
    public float walkSpeed;
    public float runSpeed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = GetComponent<Animator>();

        fov = GetComponent<FieldOfView>();
    }
}
