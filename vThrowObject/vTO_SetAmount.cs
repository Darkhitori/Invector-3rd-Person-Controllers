using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThrowObject")]
	[Tooltip(" ")]
	public class vTO_SetAmount : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThrowObject))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt value;
		
		public FsmBool everyFrame;

		vThrowObject theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThrowObject>();


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
			
			theScript.SetAmount(value.Value);            
		}

	}
}