using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Check if item is equipped in specific EquipPoint ")]
	public class vIM_ItemIsInSpecificEquipPoint : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		public enum ItemIsInSpecificEquipPoint
		{
			id_equipPointName,
			itemName_equipPointName
		}
		
		public ItemIsInSpecificEquipPoint methods;
		
		public FsmInt id;
		
		public FsmString itemName;
		
		public FsmString equipPointName;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool itemIsInSpecificEquipPoint;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			methods = ItemIsInSpecificEquipPoint.id_equipPointName;
			id = null;
			itemName = "";
			equipPointName = "";
			itemIsInSpecificEquipPoint = false;
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
			
			switch(methods)
			{
			case ItemIsInSpecificEquipPoint.id_equipPointName:
				itemIsInSpecificEquipPoint.Value = theScript.ItemIsInSpecificEquipPoint(id.Value, equipPointName.Value);
				break;
			case ItemIsInSpecificEquipPoint.itemName_equipPointName:
				itemIsInSpecificEquipPoint.Value = theScript.ItemIsInSpecificEquipPoint(itemName.Value, equipPointName.Value);
				break;
			}
			
			
				
		}

	}
}