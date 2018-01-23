using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vWaypoint")]
	[Tooltip(" ")]
	public class vWP_GetRandomSubPoint : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vWaypoint))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmVector3)]
		public FsmVector3 getSubPoint;
		
		public FsmBool everyFrame;

		vWaypoint theScript;
  
		public override void Reset()
		{
			gameObject = null;
			getSubPoint = new Vector3(0,0,0);
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vWaypoint>();


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
			
			getSubPoint.Value = theScript.GetRandomSubPoint();            
		}

	}
}