using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ML-Agent Packages를 가져오기
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class RollerAgent : Agent
{
    Rigidbody rBody;

    //~중요~ 타겟의 위치를 변수로 둠
    public GameObject[] Target;
    public GameObject[] obstacles;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }


    public override void OnEpisodeBegin() //초기화
    {
        FruitCount = 0;
        obstacleCount = 0;
        prevIndex = 0;
        WallCount = 0;

        //Agent 위치 초기화
        //if (this.transform.localPosition.y <= 0)
        //{
        this.rBody.angularVelocity = Vector3.zero;
        this.rBody.velocity = Vector3.zero;
        this.transform.localPosition = new Vector3(0, 0.5f, 0);
        //}

        //Target을 맞췄을 때
        //Target의 위치를 랜덤하게 배치
        /*        foreach (GameObject a in Target)
                {
                    a.SetActive(true);
                    a.transform.localPosition = new Vector3(Random.Range(-12, 12), 0.5f, Random.Range(-9, 9));
                }*/
        //Random.Range(min,max)값으로 줘도 된다.
        //Reword 값주는 것을 여기다 해줘도 된다. OnAction에 줘도 됨

        print("Begin작동");
    }

    // 환경 감시를 위한 함수
    public override void CollectObservations(VectorSensor sensor)
    {
        // 타겟의 위치를 알기
        for (int i = 0; i < Target.Length; i++)
        {
            sensor.AddObservation(Target[i].transform.localPosition);
        }

        // Agent 위치 알기
        sensor.AddObservation(this.transform.localPosition);

        // 장애물 위치 알기
        //sensor.AddObservation(obstacle.localPosition);

        //속도값을 줘서 안 떨어지게 하기
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
    }

    // Action 할당과 보상 설정
    public float forceMultiplier = 10;

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        /*// Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.z = actionBuffers.ContinuousActions[1];
        rBody.AddForce(controlSignal * forceMultiplier);*/

        //MoveAgent(actionBuffers);

        if (Target[prevIndex].activeSelf == true)
        {
            Move(actionBuffers);
        }

        else if (Target[prevIndex + 1].activeSelf == true)
        {
            Move2(actionBuffers);
        }

        else if (Target[prevIndex + 2].activeSelf == true)
        {
            Move3(actionBuffers);
        }

        else if (Target[prevIndex + 3].activeSelf == true)
        {
            Move4(actionBuffers);
        }
        // 가만히 있으면 - 보상을 받는다.
        //  AddReward(-0.001f);

        if (FruitCount == FruitMaxCount)
        {
            SetReward(3.0f);
            print("TargetAll:" + " " + "2.0Reward");
            EndEpisode();
            print("용과:" + " " + "End");
        }

        //Fell off platform
        if (this.transform.localPosition.y < 0)
        {
            //실패 바닥색
            //Floor.material = FailColor;
            EndEpisode();
        }
    }

    public void MoveAgent(ActionBuffers actionBuffers)
    {
        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;
        var continousAction = actionBuffers.ContinuousActions;
        var discreteAction = actionBuffers.DiscreteActions;

        var forward = Mathf.Clamp(continousAction[0], 0f, 1f);
        var right = Mathf.Clamp(continousAction[1], -1f, 1f);
        var rotate = Mathf.Clamp(continousAction[2], -1f, 1f);

        dirToGo = transform.forward * forward;
        dirToGo += transform.right * right;
        rotateDir = -transform.up * -rotate;

        rBody.AddForce(dirToGo * speed, ForceMode.VelocityChange);
        transform.Rotate(rotateDir, Time.fixedDeltaTime * turnSpeed);

        if (rBody.velocity.sqrMagnitude > 25f)
        {
            rBody.velocity *= 0.95f;
        }
    }

    // 속도값
    float speed = 0.3f;
    float turnSpeed = 50f;

    // Target의 Index값
    int prevIndex;
    int index;


    //처음 Move
    public void Move(ActionBuffers actionBuffers)
    {
        Vector3 dir = Target[prevIndex].transform.position - this.transform.position;
        dir.Normalize();
        //this.transform.position += actionBuffers.ContinuousActions[0]*dir * speed * Time.deltaTime;
        rBody.AddForce(actionBuffers.ContinuousActions[0] * dir * speed, ForceMode.VelocityChange);
    }

    //Target2 Move
    public void Move2(ActionBuffers actionBuffers)
    {
        Vector3 dir = Target[prevIndex + 1].transform.position - this.transform.position;
        dir.Normalize();
        //this.transform.position += actionBuffers.ContinuousActions[0]*dir * speed * Time.deltaTime;
        rBody.AddForce(actionBuffers.ContinuousActions[0] * dir * speed, ForceMode.VelocityChange);
    }

    //Target3 Move
    public void Move3(ActionBuffers actionBuffers)
    {
        Vector3 dir = Target[prevIndex + 2].transform.position - this.transform.position;
        dir.Normalize();
        //this.transform.position += actionBuffers.ContinuousActions[0]*dir * speed * Time.deltaTime;
        rBody.AddForce(actionBuffers.ContinuousActions[0] * dir * speed, ForceMode.VelocityChange);
    }

    //Target4 Move
    public void Move4(ActionBuffers actionBuffers)
    {
        Vector3 dir = Target[prevIndex + 3].transform.position - this.transform.position;
        dir.Normalize();
        //this.transform.position += actionBuffers.ContinuousActions[0]*dir * speed * Time.deltaTime;
        rBody.AddForce(actionBuffers.ContinuousActions[0] * dir * speed, ForceMode.VelocityChange);
    }

    // 용과 충돌 개수 (++ 보상)
    public int FruitCount = 0;
    public int FruitMaxCount = 4;

    // 장애물 충돌 개수 (-- 보상)
    public int WallCount = 0;
    public int WallMaxCount = 20;

    // 장애물 충돌 개수 (-- 보상)
    public int obstacleCount;
    public int obstacleMaxCount = 5;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Target01") == true && FruitCount < FruitMaxCount)
        {
            AddReward(1.0f);
            FruitCount++;
            print("Target01:" + " " + "1.0 Reward");
            collision.gameObject.SetActive(false);
            GameManager1.Instance.count--;
            /*if (collision.gameObject.activeSelf == false)
            {
                Move2(ActionBuffers);
            }*/
        }

        if (collision.gameObject.CompareTag("Target02") == true && FruitCount < FruitMaxCount)
        {
            AddReward(1.0f);
            FruitCount++;
            print("Target02:" + " " + "1.0 Reward");
            collision.gameObject.SetActive(false);
            GameManager1.Instance.count--;
            /*if (collision.gameObject.activeSelf == false)
            {
                Move3(ActionBuffers actionBuffers);
            }*/
        }

        if (collision.gameObject.CompareTag("Target03") == true && FruitCount < FruitMaxCount)
        {
            AddReward(1.0f);
            FruitCount++;
            print("Target03:" + " " + "1.0 Reward");
            collision.gameObject.SetActive(false);
            GameManager1.Instance.count--;
            /*if (collision.gameObject.activeSelf == false)
            {
                Move4(ActionBuffers actionBuffers);
            }*/
        }

        if (collision.gameObject.CompareTag("Target04") && FruitCount < FruitMaxCount)
        {
            AddReward(1.0f);
            FruitCount++;
            print("Target04:" + " " + "1.0Reward");
            collision.gameObject.SetActive(false);
            GameManager1.Instance.count--;
        }

        if (collision.gameObject.CompareTag("wall"))
        {
            WallCount++;
            //print(WallCount);
            AddReward(-0.01f);
            //EndEpisode();
            print("벽:" + " " + "-0.001Reward");
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            obstacleCount++;
            AddReward(-0.01f);
            print("장애물:" + " " + "-0.5fReward");
        }
        /*
                if (collision.gameObject.CompareTag("wall") && WallCount == WallMaxCount)
                {
                    AddReward(-0.002f);
                    print("벽:" + " " + "-0.002Reward");
        *//*            EndEpisode();
                    print("벽:" + " " + "End");*//*
                }
        */
        /*
                if (collision.gameObject.CompareTag("Obstacle") && obstacleCount == obstacleMaxCount)
                {
                    AddReward(-0.5f);
                    print("장애물벽:" + " " + "-0.5Reward");
        *//*            EndEpisode();
                    print("장애물:" + " " + "End");*//*
                }
        */
    }

    //수평수직 입력 축값에 해당하는 액션을 생성한다.
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}
