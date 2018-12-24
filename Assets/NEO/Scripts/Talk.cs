using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour {
    [SerializeField]
    Material MouthShut;
    [SerializeField]
    Material MouthOpen;
    int i;


    void Update () {
        i++;
        if (i < 160)
            {
            this.GetComponent<MeshRenderer>().material = MouthOpen;
            }
        if(i > 160)
        {
            this.GetComponent<MeshRenderer>().material = MouthShut;
        }
        if(i > 170)
        {
            i = 0;
        }

	}
}
