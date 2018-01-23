using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInput")]
	[Tooltip("Get Axis like a buttonDown ")]
	public class vI_GetAxisButtonDown : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInput))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat value;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool getAxisButtonDown;
		
		[ActionSection("Event")]
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		GenericInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			value = 0.5f;
			getAxisButtonDown = false;
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

			getAxisButtonDown.Value = theScript.GetAxisButtonDown(value.Value); 
			if (getAxisButtonDown.Value)
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}