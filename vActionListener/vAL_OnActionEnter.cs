using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vActionListener")]
	[Tooltip(" ")]
	public class vAL_OnActionEnter : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vActionListener))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(Collider))]
		public FsmObject other;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vActionListener theScript;
  

		public override void Reset()
		{
			gameObject = null;
			other = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vActionListener>();


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
			var coll = other.Value as Collider;
			if (coll == null)
			{
				return;
			}
			
			theScript.OnActionEnter(coll);   
			if (sendEvent == null)
			{
				return;
			}
			else
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}