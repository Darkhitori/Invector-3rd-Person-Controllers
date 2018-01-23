using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vLockOnBehaviour")]
	[Tooltip("change the current target to next target of possibles target if exist more than 1 target in list ")]
	public class vLOB_ChangeTarget : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vLockOnBehaviour))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt value;
		
		public FsmBool everyFrame;

		vLockOnBehaviour theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vLockOnBehaviour>();


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
			
			theScript.ChangeTarget(value.Value);            
		}

	}
}