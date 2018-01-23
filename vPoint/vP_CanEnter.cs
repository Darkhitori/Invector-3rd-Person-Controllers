using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vPoint")]
	[Tooltip(" ")]
	public class vP_CanEnter : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vPoint))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject visitor;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool canEnter;
		
		public FsmBool everyFrame;

		vPoint theScript;
  

		public override void Reset()
		{
			gameObject = null;
			visitor = null;
			canEnter = false;
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
			
			canEnter.Value = theScript.CanEnter(visitor.Value.transform);
				
			            
		}

	}
}