﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemWindowDisplay")]
	[Tooltip(" ")]
	public class vIWD_OnSubmit : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemWindowDisplay))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vItemSlot))]
		public FsmObject slot;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vItemWindowDisplay theScript;
  

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

			theScript = go.GetComponent<vItemWindowDisplay>();


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
			
			theScript.OnSubmit(vSlot);
			if(sendEvent == null)
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