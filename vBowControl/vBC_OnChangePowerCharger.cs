using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vBowControl")]
	[Tooltip(" ")]
	public class vBC_OnChangePowerCharger : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vBowControl))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat charger;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vBowControl theScript;
  

		public override void Reset()
		{
			gameObject = null;
			charger = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vBowControl>();


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
			
			theScript.OnChangePowerCharger(charger.Value);
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