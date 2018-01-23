using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.IK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vIKSolver")]
	[Tooltip("Set IK Position ")]
	public class vIKS_SetIKPosition : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vIKSolver))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 ikPosition;
		
		public FsmBool everyFrame;

		vIKSolver theScript;
  

		public override void Reset()
		{
			gameObject = null;
			ikPosition = new Vector3(0,0,0);
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vIKSolver>();


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
			
			theScript.SetIKPosition(ikPosition.Value);            
		}

	}
}