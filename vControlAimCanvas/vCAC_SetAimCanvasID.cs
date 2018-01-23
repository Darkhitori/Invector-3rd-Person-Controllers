using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vControlAimCanvas")]
	[Tooltip("Set AimCanvas ID. if id do not exist,this change to defaultAimCanvas id 0 ")]
	public class vCAC_SetAimCanvasID : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vControlAimCanvas))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt id;
		
		public FsmBool everyFrame;

		vControlAimCanvas theScript;
  

		public override void Reset()
		{
			gameObject = null;
			id = null;
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
			
			theScript.SetAimCanvasID(id.Value);            
		}

	}
}