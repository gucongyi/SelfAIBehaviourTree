using FluentBehaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAIBehaviourTree : MonoBehaviour
{
    ITreeNode treeFrontNode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (treeFrontNode != null)
        {
            treeFrontNode.tick();
        }
    }
}
