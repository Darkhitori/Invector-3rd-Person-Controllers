using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInput")]
	[Tooltip("Get Button Down ")]
	public class vI_GetButtonDown : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInput))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool getButtonDown;
		
		[ActionSection("Event")]
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		GenericInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			getButtonDown = false;
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

			getButtonDown.Value = theScript.GetButtonDown(); 
			if (getButtonDown.Value)
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}