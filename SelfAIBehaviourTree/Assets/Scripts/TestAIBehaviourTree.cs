using FluentBehaviour;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAIBehaviourTree : MonoBehaviour
{
    public GameObject Player;
    GameObject Self;
    public Transform transOriginPoint;
    float disField = 10;
    float disOriginPoint = 5;
    bool isAttack;
    float timeInAttack = 1f;
    /// <summary>
    /// dota中野怪Ai
    /// Root sel:|->站立seq:->1.没有英雄在范围内
    ///                       2.1s内没有被打
    ///          |->攻击seq:->1.英雄在范围内
    ///                       2.1s内被打
    ///                       3.与根据点距离小于n
    ///                       4.走向目标点->seq:与目标点距离大于m
    ///                       5.攻击
    ///         |->回守seq:->1.与根据点距离大于n
    ///                      2.往目标点移动
    /// </summary>
    SelectorNode treeFrontNode;
    // Start is called before the first frame update
    void Start()
    {
        Self = gameObject;
        treeFrontNode = new SelectorNode("Root");

        SequenceNode StandNode = new SequenceNode("Stand");
        ConditionNode isInFieldNode = new ConditionNode("InField", IsInField);
        ConditionNode isAttackedNode = new ConditionNode("isAttacked", IsAttacked);
        InverterNode isNotAttackedNode = new InverterNode("isNotAttacked", isAttackedNode);
        ActionNode standActionNode = new ActionNode("站立", OnStandAction);
        StandNode.addChild(isInFieldNode);
        StandNode.addChild(isNotAttackedNode);
        StandNode.addChild(standActionNode);

        SequenceNode AttackNode = new SequenceNode("Attack");

        SequenceNode RebackNode = new SequenceNode("Reback");
        treeFrontNode.addChild(StandNode);
        treeFrontNode.addChild(AttackNode);
        treeFrontNode.addChild(RebackNode);
    }

    private TreeStatus OnStandAction()
    {
        Debug.LogError("站立");
        return TreeStatus.kSuccess;
    }

    private bool IsAttacked()
    {
        //test 
        return false;
        //return true;
    }

    private bool IsInField()
    {
        bool isInField = false;
        if (Vector3.Distance(Player.transform.position, Self.transform.position) <= disField)
        {
            isInField = true;
        }
        return isInField;
    }

    // Update is called once per frame
    void Update()
    {
        if (treeFrontNode != null)
        {
            //根节点遍历即可，子节点会被递归遍历
            treeFrontNode.tick();
        }
    }
}
