using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonMotor")]
	[Tooltip(" ")]
	public class vTPM_RotateToTarget : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonMotor))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject target;
		
		public FsmBool everyFrame;

		vThirdPersonMotor theScript;
  

		public override void Reset()
		{
			gameObject = null;
			target = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonMotor>();


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
			
			theScript.RotateToTarget(target.Value.transform);            
		}

	}
}