﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemWindow")]
	[Tooltip(" ")]
	public class vIW_OnCancel : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemWindow))] 
		public FsmOwnerDefault gameObject;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vItemWindow theScript;
  

		public override void Reset()
		{
			gameObject = null;
			sendEvent = null;
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
			
			theScript.OnCancel();
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