using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInventory")]
	[Tooltip(" ")]
	public class vI_OnReloadGame : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInventory))] 
		public FsmOwnerDefault gameObject;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vInventory theScript;
  

		public override void Reset()
		{
			gameObject = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vInventory>();


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
			
			theScript.OnReloadGame();
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