﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vThirdPersonMotor")]
	[Tooltip("Return the ground angle ")]
	public class vTPM_GroundAngle : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vThirdPersonMotor))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmFloat)]
		public FsmFloat groundAngle;
		
		public FsmBool everyFrame;

		vThirdPersonMotor theScript;
  

		public override void Reset()
		{
			gameObject = null;
			groundAngle = null;
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
			
			groundAngle.Value = theScript.GroundAngle();            
		}

	}
}