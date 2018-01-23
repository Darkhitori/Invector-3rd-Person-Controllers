using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vControlAimCanvas")]
	[Tooltip("Enable or Disable the current Scope ")]
	public class vCAC_SetActiveScopeCamera : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vControlAimCanvas))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool value;
		public FsmBool useUI;
		
		public FsmBool everyFrame;

		vControlAimCanvas theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = false;
			useUI = false;
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
			
			theScript.SetActiveScopeCamera(value.Value, useUI.Value);            
		}

	}
}