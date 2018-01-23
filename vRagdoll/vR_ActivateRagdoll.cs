using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vRagdoll")]
	[Tooltip("active ragdoll - call this method to turn the ragdoll on  ")]
	public class vR_ActivateRagdoll : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vRagdoll))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool everyFrame;

		vRagdoll theScript;
  

		public override void Reset()
		{
			gameObject = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vRagdoll>();


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
			
			theScript.ActivateRagdoll();            
		}

	}
}