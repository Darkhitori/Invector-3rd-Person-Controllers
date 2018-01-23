using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vDisplayWeaponStandalone")]
	[Tooltip(" ")]
	public class vDWS_SetWeaponText : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vDisplayWeaponStandalone))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString text;
		
		public FsmBool everyFrame;

		vDisplayWeaponStandalone theScript;
  

		public override void Reset()
		{
			gameObject = null;
			text = "";
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vDisplayWeaponStandalone>();


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
			
			theScript.SetWeaponText(text.Value);            
		}

	}
}