using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Equip or change Item to current equiped slot of area by equipPointName ")]
	public class vIM_EquipCurrentItemToArea : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vItem))]
		public FsmObject item;
		
		public FsmInt indexOfArea;
		
		public FsmBool immediate;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			item = null;
			indexOfArea = null;
			immediate = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vItemManager>();


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
			
			theScript.EquipCurrentItemToArea(iItem, indexOfArea.Value, immediate.Value);
			
		}

	}
}