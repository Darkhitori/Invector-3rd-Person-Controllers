using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vEquipAreaControl")]
	[Tooltip(" ")]
	public class vEA_OnOpen : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vEquipAreaControl))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool value;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vEquipAreaControl theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = false;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vEquipAreaControl>();


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
			
			theScript.OnOpen(value.Value);
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