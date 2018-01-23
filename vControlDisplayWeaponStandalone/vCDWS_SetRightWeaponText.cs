using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vControlDisplayWeaponStandalone")]
	[Tooltip(" ")]
	public class vCDWS_SetRightWeaponText : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vControlDisplayWeaponStandalone))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString text;
		
		public FsmBool everyFrame;

		vControlDisplayWeaponStandalone theScript;
  

		public override void Reset()
		{
			gameObject = null;
			text = "";
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vControlDisplayWeaponStandalone>();


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
			
			theScript.SetRightWeaponText(text.Value);            
		}

	}
}