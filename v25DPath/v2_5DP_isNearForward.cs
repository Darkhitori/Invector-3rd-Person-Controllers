using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v2_5DPath")]
	[Tooltip(" ")]
	public class v2_5DP_isNearForward : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v2_5DPath))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 position;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool isNearForward;
		
		public FsmBool everyFrame;

		v2_5DPath theScript;
  

		public override void Reset()
		{
			gameObject = null;
			position = new Vector3(0,0,0);
			isNearForward = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v2_5DPath>();


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
			
			isNearForward.Value = theScript.isNearForward(position.Value);            
		}

	}
}