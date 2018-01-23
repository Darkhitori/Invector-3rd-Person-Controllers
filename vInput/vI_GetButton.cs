using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInput")]
	[Tooltip("Get Button ")]
	public class vI_GetButton : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInput))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool getButton;
		
		public FsmBool everyFrame;

		GenericInput theScript;
  

		public override void Reset()
		{
			gameObject = null;
			getButton = false;
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

			getButton.Value = theScript.GetButton();            
		}

	}
}