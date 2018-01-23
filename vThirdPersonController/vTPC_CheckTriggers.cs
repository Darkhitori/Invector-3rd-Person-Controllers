using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonController")]
	[Tooltip("Call this in OnTriggerEnter or OnTriggerStay to check if enter in triggerActions ")]
	public class vTPC_CheckTriggers : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonController))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(Collider))]
		public FsmObject other;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vThirdPersonController theScript;
  

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

			theScript = go.GetComponent<vThirdPersonController>();


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
			var vOther = other.Value as Collider;
			if (vOther == null)
			{
				return;
			}
			
			theScript.CheckTriggers(vOther);
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