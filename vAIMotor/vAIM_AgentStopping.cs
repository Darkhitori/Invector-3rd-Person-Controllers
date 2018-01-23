using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v_AIMotor")]
	[Tooltip(" ")]
	public class vAIM_AgentStopping : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v_AIMotor))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool isAgentStopping;
		
		public FsmBool everyFrame;

		v_AIMotor theScript;
  

		public override void Reset()
		{
			gameObject = null;
			isAgentStopping = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v_AIMotor>();


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
			
			isAgentStopping.Value = theScript.AgentStopping();            
		}

	}
}