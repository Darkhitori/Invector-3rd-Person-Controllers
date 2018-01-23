using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vPoint")]
	[Tooltip(" ")]
	public class vP_Exit : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vPoint))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject visitor;
		
		public FsmBool everyFrame;

		vPoint theScript;
  

		public override void Reset()
		{
			gameObject = null;
			visitor = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vPoint>();


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
			
			theScript.Exit(visitor.Value.transform);
				
			            
		}

	}
}