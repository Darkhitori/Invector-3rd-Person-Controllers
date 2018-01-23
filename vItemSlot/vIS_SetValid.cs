using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemSlot")]
	[Tooltip(" ")]
	public class vIS_SetValid : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemSlot))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool value;
		
		public FsmBool everyFrame;

		vItemSlot theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = false;
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
			
			theScript.SetValid(value.Value);
			
		}

	}
}