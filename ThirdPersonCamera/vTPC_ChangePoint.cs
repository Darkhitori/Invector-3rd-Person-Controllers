using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonCamera")]
	[Tooltip("Change the lookAtPoint of current state if cameraMode is FixedPoint ")]
	public class vTPC_ChangePoint : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonCamera))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString pointName;
		
		public FsmBool everyFrame;

		vThirdPersonCamera theScript;
  

		public override void Reset()
		{
			gameObject = null;
			pointName = "";
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonCamera>();


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
			
			theScript.ChangePoint(pointName.Value);
		}

	}
}