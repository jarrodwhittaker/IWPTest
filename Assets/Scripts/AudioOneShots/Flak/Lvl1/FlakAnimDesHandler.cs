using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakAnimDesHandler : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		AudioManager.Instance.FlakDes1();
	}
}
