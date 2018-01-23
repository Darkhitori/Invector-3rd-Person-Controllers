using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonCamera")]
	[Tooltip("Camera Rotation behaviour ")]
	public class vTPC_RotateCamera : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonCamera))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat x;
		
		public FsmFloat y;
		
		public FsmBool everyFrame;

		vThirdPersonCamera theScript;
  

		public override void Reset()
		{
			gameObject = null;
			x = null;
			y = null;
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
			
			theScript.RotateCamera(x.Value, y.Value);
		}

	}
}