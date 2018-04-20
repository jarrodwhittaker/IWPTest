﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pak5AnimDesHandler : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		AudioManager.Instance.PakDes5();
	}
}
