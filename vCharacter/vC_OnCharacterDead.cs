using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vGameController")]
	[Tooltip(" ")]
	public class vC_OnCharacterDead : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vGameController))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject _gameObject;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vGameController theScript;
  

		public override void Reset()
		{
			gameObject = null;
			_gameObject = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vGameController>();


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
			
			theScript.OnCharacterDead(_gameObject.Value); 
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