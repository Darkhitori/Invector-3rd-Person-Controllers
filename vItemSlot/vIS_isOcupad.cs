using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemSlot")]
	[Tooltip(" ")]
	public class vIS_isOcupad : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemSlot))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool item;
		
		public FsmBool everyFrame;

		vItemSlot theScript;
  

		public override void Reset()
		{
			gameObject = null;
			item = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vItemSlot>();


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
			
			item.Value = theScript.isOcupad();
			
		}

	}
}