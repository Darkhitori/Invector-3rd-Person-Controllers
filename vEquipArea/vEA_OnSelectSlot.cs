using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vEquipArea")]
	[Tooltip(" ")]
	public class vEA_OnSelectSlot : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vEquipArea))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vItemSlot))]
		public FsmObject slot;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vEquipArea theScript;
  

		public override void Reset()
		{
			gameObject = null;
			slot = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vEquipArea>();


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
			
			theScript.OnSelectSlot(vSlot);
			if (sendEvent == null)
			{
				return;
			}
			else
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}