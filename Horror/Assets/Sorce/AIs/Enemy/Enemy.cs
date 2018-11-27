using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target; //プレイヤーの位置を感知する
    static Vector3 pos;
    NavMeshAgent agent;

    public Transform[] points;
    private int destPoint = 0;

    float agentToPatroldistance;
    float agentToTargetdistance;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        //DoPatrol();
        agent.autoBraking = false;
        GotoNextPoint();
    }


    void Update()
    {
        //エネミーと目的地の距離
        agentToPatroldistance = Vector3.Distance(this.agent.transform.position, pos);

        //エネミーとプレイヤーの距離
        agentToTargetdistance = Vector3.Distance(this.agent.transform.position, target.transform.position);


        //プレイヤーとエネミーの距離が3f以下になると追跡開始
        if (agentToTargetdistance <= 4f)
        {
            DoTracking();

            //プレイヤーと目的地の距離が0.5f以下になると次の目的地をランダム指定
        }
        else if (!agent.pathPending && agent.remainingDistance < 1.5f)
        {
            GotoNextPoint();

        }

    }
    //

    //エネミーが向かう先をランダムに指定する
    //public void DoPatrol()
    //{
      //  var x = Random.Range(-0.3f, 0.3f);
       // var z = Random.Range(-0.3f, 0.3f);
        //pos = new Vector3(x, 0, z);
        //agent.SetDestination(pos);
    //}

    //targetに指定したplayerを追いかける
    public void DoTracking()
    {
        pos = target.position;
        agent.SetDestination(pos);
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }
}
