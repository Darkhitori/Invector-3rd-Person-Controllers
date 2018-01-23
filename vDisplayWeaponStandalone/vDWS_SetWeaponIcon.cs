using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vDisplayWeaponStandalone")]
	[Tooltip(" ")]
	public class vDWS_SetWeaponIcon : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vDisplayWeaponStandalone))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(Sprite))]
		public FsmObject icon;
		
		public FsmBool everyFrame;

		vDisplayWeaponStandalone theScript;
  

		public override void Reset()
		{
			gameObject = null;
			icon = null;
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
			var vIcon = icon.Value as Sprite;
			if (vIcon == null)
			{
				return;
			}
			
			theScript.SetWeaponIcon(vIcon);            
		}

	}
}