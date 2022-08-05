using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace FiveMModsWoofer
{
	internal class Security
	{
		public static NetworkManager.LoginSystemV1 LoginSystemV1 = new NetworkManager.LoginSystemV1("45.142.115.67");
		public static string HWID { get; set; }
		public enum Options
		{
			Register = 1,
			Login,
			License,
			GenerateLicense,
			Deletelicense,
			Acountsharing,
			Loginrequest,
			Block,
			BlockHWID,
			UnBlockHWID,
			Security,
			AntiCopy,
			ScreenShot
		}
		public static string GetIP()
		{
			WebClient webClient = new WebClient();
			return webClient.DownloadString("https://ipv4.wtfismyip.com/text");
		}

		public static void DebuggerAlert(string Debugger)
		{
			LoginSystemV1.sendPacket(Options.Security.ToString() +" " + GetIP() + " " + GetHWID());
		}

		public static void DebuggerCheck()
		{
            try
            {
				string[] array = new string[68]
							{
			"ollydbg", "ida", "ida64", "idag", "idag64", "idaw", "idaw64", "idaq", "idaq64", "idau",
			"idau64", "scylla", "scylla_x64", "scylla_x86", "protection_id", "x64dbg", "x32dbg", "windbg", "reshacker", "ImportREC",
			"Lunar Engine", "lunarengine-i386", "lunarengine-x86_64", "lunarengine-x86_64-SSE4-AVX2", "gtutorial-i386", "IMMUNITYDEBUGGER", "MegaDumper", "Cheat Engine", "cheatengine-i386", "cheatengine-x86_64",
			"FolderChangesView", "cheatengine-x86_64-SSE4-AVX2", "HTTPDebuggerUI", "HTTPDebuggerSvc", "HTTP Debugger", "HTTP Debugger (32 bit)", "HTTP Debugger (64 bit)", "OLLYDBG", "Lunar Engine 7.2", "disassembly",
			"Debug", "[CPU", "Immunity", "WinDbg", "Cheat Engine 7.2", "Import reconstructor", "MegaDumper 1.0 by CodeCracker / SnD", "Processhacker", "KsDumperClient", "ProcessHacker",
			"procmon", "Wireshark", "vFiddler", "Xenos64", "HTTP Debugger Windows Service (32 bit)", "KsDumper", "IDA: Quick start", "Memory Viewer", "Process List", "dnSpy",
			"dotPeek64", "dotPeek32", "OzCode", "FusionReactor", "Extreme Dumper", "ExtremeDumper", "x32dbg", "x64dbg"
							};
				while (true)
				{
					for (int i = 0; i < array.Length; i++)
					{
						Process[] processesByName = Process.GetProcessesByName(array[i]);
						if (processesByName.Length != 0)
						{
							Process[] processesByName2 = Process.GetProcessesByName(array[i]);
							Process[] array2 = processesByName2;
							foreach (Process process in array2)
							{
								process.Kill();
								process.WaitForExit();
								process.Dispose();
							}
							DebuggerAlert(array[i]);
							//Environment.Exit(0);
						}
					}
				}
			}
			catch(Exception e)
            {
				Console.WriteLine(e.ToString());
            }
			
		}

		public static string GetHWID()
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = "cmd.exe";
			processStartInfo.Arguments = "/C wmic baseboard get serialnumber";
			process.StartInfo = processStartInfo;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			process.Start();
			process.StandardOutput.ReadLine();
			process.StandardOutput.ReadLine();
			return process.StandardOutput.ReadLine();
		}
	}
}
