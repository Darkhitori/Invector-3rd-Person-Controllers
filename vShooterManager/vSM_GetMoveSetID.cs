﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vShooterManager")]
	[Tooltip(" ")]
	public class vSM_GetMoveSetID : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vShooterManager))] 
		public FsmOwnerDefault gameObject;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmInt)]
		public FsmInt moveSetID;
		
		public FsmBool everyFrame;

		vShooterManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			moveSetID = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vShooterManager>();


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
			
			moveSetID.Value = theScript.GetMoveSetID();            
		}

	}
}