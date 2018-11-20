using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattryBlock : MonoBehaviour {

    public GameObject tablet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        // プレイヤーが接触したら
        if(other.gameObject.name == "Player")
        {
            if(tablet.GetComponent<Tablet>().Battery >= tablet.GetComponent<Tablet>().fullBattry) { return; }

            // バッテリーを回復する
            tablet.GetComponent<Tablet>().Battery += 0.02f;
        }
    }
}
