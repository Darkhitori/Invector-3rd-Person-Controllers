using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemWindow")]
	[Tooltip(" ")]
	public class vIW_InsertSpaceBeforeUpperCAse : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemWindow))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString input;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmString)]
		public FsmString result;
		
		public FsmBool everyFrame;

		vItemWindow theScript;
  

		public override void Reset()
		{
			gameObject = null;
			input = "";
			result = "";
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vItemWindow>();


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
			
			result.Value = theScript.InsertSpaceBeforeUpperCAse(input.Value);            
		}

	}
}