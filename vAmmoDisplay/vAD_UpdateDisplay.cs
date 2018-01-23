using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vAmmoDisplay")]
	[Tooltip(" ")]
	public class vAD_UpdateDisplay : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vAmmoDisplay))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString text;
		
		public FsmInt id;
		
		public FsmBool everyFrame;

		vAmmoDisplay theScript;
  

		public override void Reset()
		{
			gameObject = null;
			text = "";
			id = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vAmmoDisplay>();


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
			
			theScript.UpdateDisplay(text.Value, id.Value);            
		}

	}
}