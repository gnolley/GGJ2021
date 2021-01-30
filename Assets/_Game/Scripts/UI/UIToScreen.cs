using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToScreen : MonoBehaviour
{
	[SerializeField] private UIScreenManager screenManager;

	public void ToListScreen() => screenManager.GoToScreen(UIScreenManager.UIScreens.ListScreen);
	public void ToEmailScreen() => screenManager.GoToScreen(UIScreenManager.UIScreens.EmailScreen);
}
