using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwake : MonoBehaviour
{
    EnemyAwake AwakeScript;
    AIScript script;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 5 * 5)
        {
            Awaken();
        }
    }
    private GameObject player;


    void Awaken()
    {
        script = GetComponent<AIScript>();
        script.enabled = true;

        AwakeScript = GetComponent<EnemyAwake>();
        AwakeScript.enabled = false;
    }
}
