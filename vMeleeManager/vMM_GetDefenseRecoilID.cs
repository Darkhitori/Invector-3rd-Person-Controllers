﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vMeleeManager")]
	[Tooltip("Get defense recoilID for break attack ")]
	public class vMM_GetDefenseRecoilID : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vMeleeManager))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmInt)]
		public FsmInt defenseRecoilID;
		
		public FsmBool everyFrame;

		vMeleeManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			defenseRecoilID = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vMeleeManager>();


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
			
			defenseRecoilID.Value = theScript.GetDefenseRecoilID();            
		}

	}
}