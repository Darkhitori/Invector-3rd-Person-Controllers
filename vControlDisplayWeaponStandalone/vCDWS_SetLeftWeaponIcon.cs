using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vControlDisplayWeaponStandalone")]
	[Tooltip(" ")]
	public class vCDWS_SetLeftWeaponIcon : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vControlDisplayWeaponStandalone))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(Sprite))]
		public FsmObject icon;
		
		public FsmBool everyFrame;

		vControlDisplayWeaponStandalone theScript;
  

		public override void Reset()
		{
			gameObject = null;
			icon = null;
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
			var vIcon = icon.Value as Sprite;
			if (vIcon == null)
			{
				return;
			}
			
			theScript.SetLeftWeaponIcon(vIcon);            
		}

	}
}