using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInput")]
	[Tooltip("Get Double Button Down Check if button is pressed Within the defined time ")]
	public class vI_GetDoubleButtonDown : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInput))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat inputTime;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool doubleButtonDown;
		
		[ActionSection("Event")]
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		GenericInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			inputTime = 1;
			sendEvent = null;
			doubleButtonDown = false;
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

			doubleButtonDown.Value = theScript.GetDoubleButtonDown(inputTime.Value); 
			if (doubleButtonDown.Value)
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}