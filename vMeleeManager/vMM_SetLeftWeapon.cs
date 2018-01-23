using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vMeleeManager")]
	[Tooltip(" ")]
	public class vMM_SetLeftWeapon : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vMeleeManager))] 
		public FsmOwnerDefault gameObject;
		
		public enum SetLeftWeapon
		{
			weaponObject,
			weapon
		}
		
		public SetLeftWeapon methods;
		
		public FsmGameObject weaponObject;
		
		[ObjectType(typeof(vMeleeWeapon))]
		public FsmObject weapon;
		
		public FsmBool everyFrame;

		vMeleeManager theScript;
  
		public override void Reset()
		{
			gameObject = null;
			weaponObject = null;
			weapon = null;
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
			
			switch(methods)
			{
			case SetLeftWeapon.weaponObject:
				theScript.SetLeftWeapon(weaponObject.Value);
				break;
			case SetLeftWeapon.weapon:
				var vWeapon = weapon.Value as vMeleeWeapon;
				if(vWeapon == null)
				{
					return;
				}
				theScript.SetLeftWeapon(vWeapon);
				break;
			}
			            
		}

	}
}