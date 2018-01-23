using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/v_AIWeaponsControl")]
	[Tooltip("Add new Instance of Item to itemList ")]
	public class vAIW_AddItem : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(v_AIWeaponsControl))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt itemID;
		
		public FsmInt amount;
		
		public FsmBool everyFrame;

		v_AIWeaponsControl theScript;
  

		public override void Reset()
		{
			gameObject = null;
			itemID = null;
			amount = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<v_AIWeaponsControl>();


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
			
			theScript.AddItem(itemID.Value, amount.Value);            
		}

	}
}