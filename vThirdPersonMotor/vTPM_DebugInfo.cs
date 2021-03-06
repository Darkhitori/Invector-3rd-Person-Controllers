﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonMotor")]
	[Tooltip(" ")]
	public class vTPM_DebugInfo : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonMotor))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString additionalText;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmString)]
		public FsmString debugInfo;
		
		public FsmBool everyFrame;

		vThirdPersonMotor theScript;
  

		public override void Reset()
		{
			gameObject = null;
			additionalText = "";
			debugInfo = "";
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vThirdPersonMotor>();


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
			
			debugInfo.Value = theScript.DebugInfo(additionalText.Value);            
		}

	}
}