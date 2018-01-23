using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vControlAimCanvas")]
	[Tooltip("Enable or Disable the current Aim ")]
	public class vCAC_SetActiveAim : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vControlAimCanvas))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool value;
		
		public FsmBool everyFrame;

		vControlAimCanvas theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = true;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vControlAimCanvas>();


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
			
			theScript.SetActiveAim(value.Value);            
		}

	}
}