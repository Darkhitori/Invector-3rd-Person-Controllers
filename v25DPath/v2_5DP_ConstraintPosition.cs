using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v2_5DPath")]
	[Tooltip(" ")]
	public class v2_5DP_ConstraintPosition : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v2_5DPath))] 
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 pos;
		
		public FsmBool checkChangePoint;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmVector3)]
		public FsmVector3 position;
		
		public FsmBool everyFrame;

		v2_5DPath theScript;
  

		public override void Reset()
		{
			gameObject = null;
			pos = new Vector3(0,0,0);
			checkChangePoint = false;
			position = new Vector3(0,0,0);
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
			
			position.Value = theScript.ConstraintPosition(pos.Value, checkChangePoint.Value);            
		}

	}
}