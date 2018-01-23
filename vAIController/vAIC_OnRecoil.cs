﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v_AIController")]
	[Tooltip(" ")]
	public class vAIC_OnRecoil : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v_AIController))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt recoilID;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		v_AIController theScript;
  

		public override void Reset()
		{
			gameObject = null;
			recoilID = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v_AIController>();


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
			
			theScript.OnRecoil(recoilID.Value);  
			if(sendEvent == null)
			{
				return;
			}
			else
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}