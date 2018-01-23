using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v_AIAnimator")]
	[Tooltip("Trigger Recoil Animation - It's Called at the MeleeWeapon ")]
	public class vAIA_TriggerRecoil : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v_AIAnimator))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt recoil_id;
		
		public FsmBool everyFrame;

		v_AIAnimator theScript;
  

		public override void Reset()
		{
			gameObject = null;
			recoil_id = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v_AIAnimator>();


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
			
			theScript.TriggerRecoil(recoil_id.Value);            
		}

	}
}