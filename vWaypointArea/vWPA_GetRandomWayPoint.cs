using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vWaypointArea")]
	[Tooltip(" ")]
	public class vWPA_GetRandomWayPoint : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vWaypointArea))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(vWaypoint))]
		public FsmObject getRandomWayPoint;
		
		public FsmBool everyFrame;

		vWaypointArea theScript;
  
		public override void Reset()
		{
			gameObject = null;
			getRandomWayPoint = null;
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
			
			getRandomWayPoint.Value = theScript.GetRandomWayPoint();            
		}

	}
}