using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vWaypointArea")]
	[Tooltip(" ")]
	public class vWPA_GetWayPoint : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vWaypointArea))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt index;
		
		[ActionSection("Return")]
		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(vWaypoint))]
		public FsmObject getWayPoint;
		
		public FsmBool everyFrame;

		vWaypointArea theScript;
  
		public override void Reset()
		{
			gameObject = null;
			index = null;
			getWayPoint = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vWaypointArea>();


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
			
			getWayPoint.Value = theScript.GetWayPoint(index.Value);            
		}

	}
}