﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vControlDisplayWeaponStandalone")]
	[Tooltip(" ")]
	public class vCDWS_RemoveRightWeaponText : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vControlDisplayWeaponStandalone))] 
		public FsmOwnerDefault gameObject;
		
		public FsmBool everyFrame;

		vControlDisplayWeaponStandalone theScript;
  

		public override void Reset()
		{
			gameObject = null;
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
			
			theScript.RemoveRightWeaponText();            
		}

	}
}