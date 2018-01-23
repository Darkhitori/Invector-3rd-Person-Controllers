using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v_AICompanion")]
	[Tooltip("Sets the target Move to. ")]
	public class vAIC_SetMoveTo : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v_AICompanion))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject target;
		
		public FsmBool everyFrame;

		v_AICompanion theScript;
  

		public override void Reset()
		{
			gameObject = null;
			target = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v_AICompanion>();


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
			
			theScript.SetMoveTo(target.Value.transform);            
		}

	}
}