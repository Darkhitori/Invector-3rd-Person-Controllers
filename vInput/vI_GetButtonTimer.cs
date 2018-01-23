using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInput")]
	[Tooltip("Get Buttom Timer Check if button is pressed for defined time ")]
	public class vI_GetButtonTimer : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInput))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat inputTime;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool buttonTimer;
		
		[ActionSection("Event")]
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		GenericInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			inputTime = 2;
			buttonTimer = false;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<GenericInput>();


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

			buttonTimer.Value = theScript.GetButtonTimer(inputTime.Value);
			if(buttonTimer.Value)
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}