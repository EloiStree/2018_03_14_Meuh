using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeuhAntiSleep : MonoBehaviour {


	void Awake () {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
