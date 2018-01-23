using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vOnDeadTrigger")]
	[Tooltip(" ")]
	public class vODT_OnDeadHandle : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vOnDeadTrigger))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject target;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vOnDeadTrigger theScript;
  

		public override void Reset()
		{
			gameObject = null;
			target = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vOnDeadTrigger>();


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
			
			theScript.OnDeadHandle(target.Value); 
			if(sendEvent == null)
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