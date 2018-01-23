using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonAnimator")]
	[Tooltip(" ")]
	public class vTPA_TriggerAnimationState : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonAnimator))] 
		public FsmOwnerDefault gameObject;

		public FsmString animationClip;
		
		public FsmFloat transition;
		
		public FsmBool everyFrame;

		vThirdPersonAnimator theScript;
  

		public override void Reset()
		{
			gameObject = null;
			animationClip = "";
			transition = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonAnimator>();


			if (!everyFrame.Value)
			{
				DoTheMagic();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMagic();
			}
		}

		void DoTheMagic()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.TriggerAnimationState(animationClip.Value, transition.Value);            
		}

	}
}