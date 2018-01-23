using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v_AISphereSensor")]
	[Tooltip(" ")]
	public class vAISS_SetColliderRadius : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v_AISphereSensor))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat radius;
		
		public FsmBool everyFrame;

		v_AISphereSensor theScript;
  

		public override void Reset()
		{
			gameObject = null;
			radius = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v_AISphereSensor>();


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
			
			theScript.SetColliderRadius(radius.Value);            
		}

	}
}