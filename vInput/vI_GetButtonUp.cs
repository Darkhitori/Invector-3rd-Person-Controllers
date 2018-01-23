using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInput")]
	[Tooltip("Get Button Up ")]
	public class vI_GetButtonUp : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInput))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool getButtonUp;
		
		[ActionSection("Event")]
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		GenericInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			sendEvent = null;
			getButtonUp = false;
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

			getButtonUp.Value = theScript.GetButtonUp();
			if (getButtonUp.Value)
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}