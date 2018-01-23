using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vGameController")]
	[Tooltip(" ")]
	public class vC_ResetScene : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vGameController))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool everyFrame;

		vGameController theScript;
  

		public override void Reset()
		{
			gameObject = null;
			
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vGameController>();


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
			
			theScript.ResetScene(); 
			
		}

	}
}