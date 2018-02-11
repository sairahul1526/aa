﻿#pragma warning disable 0162 // code unreached.
#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
#pragma warning disable 0618 // obslolete
#pragma warning disable 0108 
#pragma warning disable 0649 //never used
#pragma warning disable 0429 //never used

/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System;
// from the excellent http://answers.unity3d.com/questions/45186/can-i-auto-run-a-script-when-editor-launches-or-a.html

///
/// This must be added to "Editor" folder: http://unity3d.com/support/documentation/ScriptReference/index.Script_compilation_28Advanced29.html
/// Execute some code exactly once, whenever the project is opened, recompiled, or run.
///

namespace AppAdvisory.AA
{
	[InitializeOnLoad]
	public class Autorun
	{

		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		private const bool DOSCIRPTINGSYMBOL = false;
		/******* TO MODIFY **********/
		private const string VSRATE = "VSRATE";
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/

		static void SetScriptingDefineSymbols () 
		{
			SetSymbolsForTarget (BuildTargetGroup.Android, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.iOS, VSRATE); 
			SetSymbolsForTarget (BuildTargetGroup.WSA, VSRATE);
			#if !UNITY_5_5_OR_NEWER
			SetSymbolsForTarget (BuildTargetGroup.Nintendo3DS, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.PS3, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.XBOX360, VSRATE);
			#endif
			SetSymbolsForTarget (BuildTargetGroup.PS4, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.PSM, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.PSP2, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.SamsungTV, VSRATE); 
			SetSymbolsForTarget (BuildTargetGroup.Standalone, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.Tizen, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.tvOS, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.WebGL, VSRATE);
			SetSymbolsForTarget (BuildTargetGroup.WiiU, VSRATE); 
			SetSymbolsForTarget (BuildTargetGroup.XboxOne, VSRATE);
		}

		static void SetSymbolsForTarget(BuildTargetGroup target, string scriptingSymbol)
		{

			if(target == BuildTargetGroup.Unknown)
				return;

			var s = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);

			string sTemp = scriptingSymbol;

			if(!s.Contains(sTemp)) 
			{

				s = s.Replace(scriptingSymbol + ";","");

				s = s.Replace(scriptingSymbol,"");  

				s = scriptingSymbol + ";" + s;

				PlayerSettings.SetScriptingDefineSymbolsForGroup(target,s);
			}
		}


		static Autorun()
		{
			EditorApplication.update += RunOnce;
		}

		static void RunOnce() 
		{
			EditorApplication.update -= RunOnce;

			// do something here. You could open an EditorWindow, for example.

			if (DGChecker.needDotween == true && (!Directory.Exists ("Assets/Demigiant") || Directory.Exists ("Assets/DOTween")))
			{
				DGChecker.OpenPopupDGCHECKERStartup();

				return;
			}


			if(DOSCIRPTINGSYMBOL)
				SetScriptingDefineSymbols ();

			int count = EditorPrefs.GetInt(WelcomeAA.PREFSHOWATSTARTUP + "autoshow",0);

			if(count == 10 || count == 50)
			{
				Application.OpenURL("http://u3d.as/oWD");
			}

			EditorPrefs.SetInt(WelcomeAA.PREFSHOWATSTARTUP + "autoshow", count + 1);

			WelcomeAA.showAtStartup = EditorPrefs.GetInt(WelcomeAA.PREFSHOWATSTARTUP, 1) == 1;
			 
			if (WelcomeAA.showAtStartup)
			{
				DGChecker.CheckItNow();
			
				WelcomeAA.OpenPopupStartup();
			}
		}
	}
}         