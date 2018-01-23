using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.IK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vIKSolver")]
	[Tooltip("Set IK Rotation ")]
	public class vIKS_SetIKRotation : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vIKSolver))] 
		public FsmOwnerDefault gameObject;
		
		public FsmQuaternion rotation;
		
		public FsmBool everyFrame;

		vIKSolver theScript;
  

		public override void Reset()
		{
			gameObject = null;
			rotation = null;
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
			
			theScript.SetIKRotation(rotation.Value);            
		}

	}
}