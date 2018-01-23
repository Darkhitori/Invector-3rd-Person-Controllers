using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemOptionWindow")]
	[Tooltip(" ")]
	public class vIOW_EnableOptions : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemOptionWindow))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vItemSlot))]
		public FsmObject slot;
		
		public FsmBool everyFrame;

		vItemOptionWindow theScript;
  

		public override void Reset()
		{
			gameObject = null;
			slot = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vItemOptionWindow>();


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
			
			var vSlot = slot.Value as vItemSlot;
			if (vSlot == null)
			{
				return;
			}
			
			theScript.EnableOptions(vSlot);
			
		}

	}
}