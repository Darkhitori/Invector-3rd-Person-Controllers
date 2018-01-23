using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInventoryWindow")]
	[Tooltip(" ")]
	public class vIW_ContainsPop_up : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInventoryWindow))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool containsPop_up;
		
		public FsmBool everyFrame;

		vInventoryWindow theScript;
  

		public override void Reset()
		{
			gameObject = null;
			containsPop_up = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vInventoryWindow>();


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
			
			containsPop_up.Value = theScript.ContainsPop_up();
			
		}

	}
}