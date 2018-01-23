using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vAmmoDisplayImage")]
	[Tooltip("Change Ammo display image by id ")]
	public class vADI_ChangeAmmoDisplayImage : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vAmmoDisplayImage))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt id;
		
		public FsmBool everyFrame;

		vAmmoDisplayImage theScript;
  

		public override void Reset()
		{
			gameObject = null;
			id = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vAmmoDisplayImage>();


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
			
			theScript.ChangeAmmoDisplayImage(id.Value);            
		}

	}
}