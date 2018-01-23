using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInventoryWindow")]
	[Tooltip(" ")]
	public class vIW_RemovePop_up : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInventoryWindow))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vWindowPop_up))]
		public FsmObject pop_up;
		
		public FsmBool everyFrame;

		vInventoryWindow theScript;
  

		public override void Reset()
		{
			gameObject = null;
			pop_up = null;
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
			var vPop_up = pop_up.Value as vWindowPop_up;
			if (vPop_up == null)
			{
				return;
			}
			
			theScript.RemovePop_up(vPop_up);
			
		}

	}
}