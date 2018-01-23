using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonAnimator")]
	[Tooltip(" ")]
	public class vTPA_IsAnimatorTag : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonAnimator))] 
		public FsmOwnerDefault gameObject;

		public FsmString tag;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool isAnimatorTag;
		
		public FsmBool everyFrame;

		vThirdPersonAnimator theScript;
  

		public override void Reset()
		{
			gameObject = null;
			tag = "";
			isAnimatorTag = false;
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

			isAnimatorTag.Value = theScript.IsAnimatorTag(tag.Value);            
		}

	}
}