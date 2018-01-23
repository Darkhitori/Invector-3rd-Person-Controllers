using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonInput")]
	[Tooltip(" ")]
	public class vTPI_ChangeCameraState : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonInput))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString cameraState;
		
		public FsmBool everyFrame;

		vThirdPersonInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			cameraState = "";
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonInput>();


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
			
			theScript.ChangeCameraState(cameraState.Value);            
		}

	}
}