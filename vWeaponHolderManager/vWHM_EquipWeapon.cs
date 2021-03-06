﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vWeaponHolderManager")]
	[Tooltip(" ")]
	public class vWHM_EquipWeapon : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vWeaponHolderManager))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vEquipArea))]
		public FsmObject equipArea;
		
		[ObjectType(typeof(vItem))]
		public FsmObject item;
		
		public FsmBool everyFrame;

		vWeaponHolderManager theScript;
  

		public override void Reset()
		{
			gameObject = null;
			equipArea = null;
			item = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vWeaponHolderManager>();


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
			var vArea = equipArea.Value as vEquipArea;
			if (vArea == null)
			{
				return;
			}
			var iItem = item.Value as vItem;
			if (iItem == null)
			{
				return;
			}
			
			theScript.EquipWeapon(vArea, iItem);
			
		}

	}
}