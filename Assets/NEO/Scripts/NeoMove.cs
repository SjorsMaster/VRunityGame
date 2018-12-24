using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoMove : MonoBehaviour {
    bool move;
    [SerializeField]
    Transform Goal;
    public void ChangeState()
    {
        move = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, Goal.position, 1 * Time.deltaTime);
        }
	}
}
