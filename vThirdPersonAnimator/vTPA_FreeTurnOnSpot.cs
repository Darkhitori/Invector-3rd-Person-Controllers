using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonAnimator")]
	[Tooltip(" ")]
	public class vTPA_FreeTurnOnSpot : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonAnimator))] 
		public FsmOwnerDefault gameObject;

		public FsmFloat direction;
		
		public FsmBool everyFrame;

		vThirdPersonAnimator theScript;
  

		public override void Reset()
		{
			gameObject = null;
			direction = null;
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

			theScript.FreeTurnOnSpot(direction.Value);            
		}

	}
}