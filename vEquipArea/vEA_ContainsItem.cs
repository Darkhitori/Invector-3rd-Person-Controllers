﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vEquipArea")]
	[Tooltip(" ")]
	public class vEA_ContainsItem : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vEquipArea))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vItem))]
		public FsmObject item;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool containsItem;
		
		public FsmBool everyFrame;

		vEquipArea theScript;
  

		public override void Reset()
		{
			gameObject = null;
			item = null;
			containsItem = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vEquipArea>();


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
			var iItem = item.Value as vItem;
			if (iItem == null)
			{
				return;
			}
			
			containsItem.Value = theScript.ContainsItem(iItem);            
		}

	}
}