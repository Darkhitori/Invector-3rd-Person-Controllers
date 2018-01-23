using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Check if item is in Specific area ")]
	public class vIM_ItemIsInSpecificEquipArea : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		public enum ItemIsInSpecificEquipArea
		{
			id_indexOfArea,
			itemName_indexOfArea
		}
		
		public ItemIsInSpecificEquipArea methods;
		
		public FsmInt id;
		
		public FsmInt indexOfArea;
		
		public FsmString itemName;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool itemIsInSpecificEquipArea;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			methods =  ItemIsInSpecificEquipArea.id_indexOfArea;
			id = null;
			indexOfArea = null;
			itemName = "";
			itemIsInSpecificEquipArea = false;
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
			case ItemIsInSpecificEquipArea.id_indexOfArea:
				itemIsInSpecificEquipArea.Value = theScript.ItemIsInSpecificEquipArea(id.Value, indexOfArea.Value);
				break;
			case ItemIsInSpecificEquipArea.itemName_indexOfArea:
				itemIsInSpecificEquipArea.Value = theScript.ItemIsInSpecificEquipArea(itemName.Value, indexOfArea.Value);
				break;
			}
			
		}

	}
}