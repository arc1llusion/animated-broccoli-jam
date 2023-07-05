using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;

public class EnemyController : BaseUnit
{
    private bool moving = false;

    private readonly float[] PossibleMovementValues = new float[] { -1, 0, 1 };

    private NavMeshAgent agent;

    private Vector3 lastPosition = Vector3.zero;

    protected override void Start()
    {
        base.Start();

        agent = GetComponent<NavMeshAgent>();
        if(agent)
        {
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }
    }

    protected override void FixedUpdate()
    {
        //movementVector = Vector2.zero;
        //if (moving)
        //{
        //    var x = PossibleMovementValues[UnityEngine.Random.Range(0, PossibleMovementValues.Length)];
        //    var y = PossibleMovementValues[UnityEngine.Random.Range(0, PossibleMovementValues.Length)];
        //    var input = new Vector2(x, y);

        //    var flattenedInput = Quaternion.Euler(30.0f, 0.0f, 0.0f) * new Vector3(input.x, 0, input.y).normalized;
        //    movementVector = Vector3.ProjectOnPlane(flattenedInput, Vector3.forward).normalized;
        //    movementVector.y = -movementVector.y;

        //    Debug.Log(movement.DistanceRemaining);
        //    if (movement.DistanceRemaining < 0.5f)
        //    {
        //        moving = false;
        //        base.ConfirmMove();
        //        gameManager.ReturnUnit(this, true);
        //    }
        //}

        //base.FixedUpdate();

        if(moving == true)
        {
            movement.UpdatePosition();
            movement.SetLastPosition(transform.position);

            if (agent.GetPathRemainingDistance() < agent.stoppingDistance || agent.GetPathRemainingDistance() < float.Epsilon || movement.DistanceRemaining <= 0.5f)
            {
                moving = false;
                base.ConfirmMove();
                gameManager.ReturnUnit(this, true);
                agent.isStopped = true;
            }
        }
    }

    public override void StartMove()
    {
        moving = true;

        var follow = FindObjectsByType<PlayerController>(FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID).OrderBy(x => Vector3.Distance(x.transform.position, transform.position)).First();
        agent.SetDestination(follow.transform.position);
        agent.isStopped = false;

        base.StartMove();
    }
}

public static class ExtensionMethods
{
    public static float GetPathRemainingDistance(this NavMeshAgent navMeshAgent)
    {
        if (navMeshAgent.pathPending ||
            navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid ||
            navMeshAgent.path.corners.Length == 0)
            return float.PositiveInfinity;

        float distance = 0.0f;
        for (int i = 0; i < navMeshAgent.path.corners.Length - 1; ++i)
        {
            distance += Vector3.Distance(navMeshAgent.path.corners[i], navMeshAgent.path.corners[i + 1]);
        }

        return distance;
    }
}
