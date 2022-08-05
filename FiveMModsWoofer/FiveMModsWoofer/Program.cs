using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;

namespace FiveMModsWoofer
{
    internal class Program
    {
		public static Spoof Spoofer = new Spoof();

		public static Fade fade = new Fade();

		public static NetworkManager.LoginSystemV1 manager = new NetworkManager.LoginSystemV1("45.142.115.67");

		static void Main(string[] args)
        {
			Thread thread = new Thread(Security.DebuggerCheck);
			thread.Start();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Title = "FiveM Mods-Spoofer by DJ HIP HOUSE#2002";
			
			Console.WriteLine("                        ███████╗██╗██╗░░░██╗███████╗███╗░░░███╗  ███╗░░░███╗░█████╗░██████╗░░██████╗\n" +
				"                        ██╔════╝██║██║░░░██║██╔════╝████╗░████║  ████╗░████║██╔══██╗██╔══██╗██╔════╝\n" +
				"                        █████╗░░██║╚██╗░██╔╝█████╗░░██╔████╔██║  ██╔████╔██║██║░░██║██║░░██║╚█████╗░\n" +
				"                        ██╔══╝░░██║░╚████╔╝░██╔══╝░░██║╚██╔╝██║  ██║╚██╔╝██║██║░░██║██║░░██║░╚═══██╗\n" +
				"                        ██║░░░░░██║░░╚██╔╝░░███████╗██║░╚═╝░██║  ██║░╚═╝░██║╚█████╔╝██████╔╝██████╔╝\n" +
				"                        ╚═╝░░░░░╚═╝░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝  ╚═╝░░░░░╚═╝░╚════╝░╚═════╝░╚═════╝░\n");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                                ░██████╗██████╗░░█████╗░░█████╗░███████╗███████╗██████╗░\n" +
				"                                ██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔════╝██╔══██╗\n" +
				"                                ╚█████╗░██████╔╝██║░░██║██║░░██║█████╗░░█████╗░░██████╔╝\n" +
				"                                ░╚═══██╗██╔═══╝░██║░░██║██║░░██║██╔══╝░░██╔══╝░░██╔══██╗\n" +
				"                                ██████╔╝██║░░░░░╚█████╔╝╚█████╔╝██║░░░░░███████╗██║░░██║");
				
			Console.WriteLine("\n\n\n");
			
			fade.FadeIn("1: Register!", Theme: true, line: true);
			fade.FadeIn("2: Login!\n\n", Theme: true, line: true);
			fade.FadeIn("Choice: ", Theme: false, line: false);
			string text = Console.ReadLine();
			string text2 = text;
			string text3 = text2;
			if (!(text3 == "2"))
			{
				if (text3 == "1")
				{
					Register();
					fade.FadeIn("Register Sucessfully!", Theme: true, line: true);
					Thread.Sleep(2000);
					Environment.Exit(0);
				}
			}
			else if (Loginin())
			{
				Spoofer.initSpoof();
			}
			else
			{
				fade.FadeIn("Permission denied!", Theme: true, line: true);
				Thread.Sleep(2000);
				Environment.Exit(0);
			}
		}
		public static bool Loginin()
		{
			fade.FadeIn("Username: ", Theme: true, line: false);
			string name = Console.ReadLine();
			fade.FadeIn("Password: ", Theme: true, line: false);
			string passwort = Console.ReadLine();
			return manager.Login(name, passwort, WindowsIdentity.GetCurrent().User?.Value);
		}

		public static void Register()
		{
			fade.FadeIn("Username: ", Theme: true, line: false);
			string name = Console.ReadLine();
			fade.FadeIn("Password: ", Theme: true, line: false);
			string passwort = Console.ReadLine();
			fade.FadeIn("License: ", Theme: true, line: false);
			string license = Console.ReadLine();
			manager.Register(name, passwort, WindowsIdentity.GetCurrent().User?.Value, license);
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

	public class Spoof
	{
		private Fade logo = new Fade();

		private Fade fade = new Fade();

		public void initSpoof()
		{
			Console.Clear();
			logo.FadeLogo(1);
			fade.FadeIn("1: Spoof Server Ban!", Theme: true, line: true);
			fade.FadeIn("2: Spoof Global Ban!", Theme: true, line: true);
			fade.FadeIn("Choice: ", Theme: false, line: true);
			string text = Console.ReadLine();
			string text2 = text;
			string text3 = text2;
			if (!(text3 == "2"))
			{
				if (text3 == "1")
				{
					SpoofServer();
				}
			}
			else
			{
				SpoofGlobal();
			}
		}

		public void SpoofServer()
		{
			string keyName = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
			string keyName2 = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			fade.FadeIn("Current HWID: " + (string)Registry.GetValue(keyName, "HwProfileGuid", "default"), Theme: false, line: true);
			fade.FadeIn("Current ProductID: " + (string)Registry.GetValue(keyName2, "ProductId", "default"), Theme: false, line: true);
			fade.FadeIn("Current BuildGUID: " + (string)Registry.GetValue(keyName2, "BuildGUID", "default"), Theme: false, line: true);
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("echo off");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q % LocalAppData%\\DigitalEntitlements");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q % userprofile %\\AppData\\Roaming\\CitizenFX");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("set hostspath =% windir %\\System32\\drivers\\etc\\hosts");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 user.auth.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 presence - heartbeat.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\HardwareID / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / va / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 332004695 - 2829936588 - 140372829 - 1002 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_chrome.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_372.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1604.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1868.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2060.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2189.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\botan.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\asi - five.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\steam.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\steam_api64.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenGame.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\profiles.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cfx_curl_x86_64.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX.ini");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\caches.XML");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\adhesive.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\discord.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("RENAME % userprofile %\\AppData\\Roaming\\discord\\0.0.309\\modules\\discord_rpc STARCHARMS_SPOOFER");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\Browser");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\db");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\dunno");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\priv");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\servers");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\subprocess");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\unconfirmed");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\authbrowser");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\crashometry");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip_mtl2");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\crashes\\*.* ");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\logs\\*.* ");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\mods\\*.* ");
				streamWriter.WriteLine(":folderclean");
				streamWriter.WriteLine("call :getDiscordVersion");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("goto :xboxclean");
				streamWriter.WriteLine(": getDiscordVersion");
				streamWriter.WriteLine("for / d %% a in (' % appdata%\\Discord\\*') do (");
				streamWriter.WriteLine("     set 'varLoc =%%a'");
				streamWriter.WriteLine("   goto :d1");
				streamWriter.WriteLine(")");
				streamWriter.WriteLine(":d1");
				streamWriter.WriteLine("for / f 'delims =\\ tokens=7' %% z in ('echo %varLoc%') do (");
				streamWriter.WriteLine("     set 'discordVersion =%%z'");
				streamWriter.WriteLine(")");
				streamWriter.WriteLine("goto :EOF");
				streamWriter.WriteLine(": xboxclean");
				streamWriter.WriteLine(" cls");
				streamWriter.WriteLine("powershell - Command ' & {Get-AppxPackage -AllUsers xbox | Remove-AppxPackage}'");
				streamWriter.WriteLine("sc stop XblAuthManager");
				streamWriter.WriteLine("sc stop XblGameSave");
				streamWriter.WriteLine("sc stop XboxNetApiSvc");
				streamWriter.WriteLine("sc stop XboxGipSvc");
				streamWriter.WriteLine("sc delete XblAuthManager");
				streamWriter.WriteLine("sc delete XblGameSave");
				streamWriter.WriteLine("sc delete XboxNetApiSvc");
				streamWriter.WriteLine("sc delete XboxGipSvc");
				streamWriter.WriteLine("reg delete 'HKLM\\SYSTEM\\CurrentControlSet\\Services\\xbgm' / f");
				streamWriter.WriteLine("schtasks / Change / TN 'Microsoft\\XblGameSave\\XblGameSaveTask' / disable");
				streamWriter.WriteLine("schtasks / Change / TN 'Microsoft\\XblGameSave\\XblGameSaveTaskLogon' / disableL");
				streamWriter.WriteLine("reg add 'HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR' / v AllowGameDVR / t REG_DWORD / d 0 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("set hostspath =% windir %\\System32\\drivers\\etc\\hosts");
				streamWriter.WriteLine("   echo 127.0.0.1 xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("   echo 127.0.0.1 user.auth.xboxlive.com >> % hostspath % ");
				streamWriter.WriteLine("   echo 127.0.0.1 presence - heartbeat.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("   rd % userprofile %\\AppData\\Local\\DigitalEntitlements / q / s");
				streamWriter.WriteLine("exit");
				streamWriter.WriteLine("goto :eof");
			}
			Process process = Process.Start(text);
			process.Start();
			string keyName3 = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
			string keyName4 = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			string value = "{FiveMMods-" + GenID(5) + "-" + GenID(5) + "-" + GenID(4) + "}";
			string value2 = GenID(2) + "." + GenID(2) + "." + GenID(4);
			string value3 = "FiveMMods-" + GenID(5) + "-" + GenID(5) + "-" + GenID(5) + "-" + GenID(5);
			string value4 = "FiveMMods - Spoofer" + GenID(8);
			string value5 = "0x00000" + GenID(3) + "(405)";
			Registry.SetValue(keyName3, "GUID", value);
			Registry.SetValue(keyName3, "HwProfileGuid", value);
			Registry.SetValue(keyName4, "InstallDate", value2);
			Registry.SetValue(keyName4, "ProductId", value3);
			Registry.SetValue(keyName4, "RegisteredOwner", value4);
			Registry.SetValue(keyName4, "UBR", value5);
			Registry.SetValue(keyName4, "BuildGUID", "FiveMMods-" + GenID(3) + "-" + GenID(3) + "-" + GenID(3));
			string text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
			text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            try
            {
				System.IO.Directory.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\CitizenFX"), true);
				System.IO.Directory.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DigitalEntitlements"), true);
				File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\CitizenFX"));
			}
			catch(Exception e)
            {

            }

			Process[] processesByName = Process.GetProcessesByName("FiveM");
			Process[] array = processesByName;
			foreach (Process process2 in array)
			{
				process2.Kill();
			}
			try
			{
				File.Delete(text2 + "\\FiveM");
			}
			catch (Exception)
			{
			}
			Console.Clear();
			Thread.Sleep(1000);
			Console.Clear();
			fade.FadeIn("Spoofed HWID: " + (string)Registry.GetValue(keyName, "HwProfileGuid", "default"), Theme: true, line: true);
			fade.FadeIn("Spoofed ProductID: " + (string)Registry.GetValue(keyName2, "ProductId", "default"), Theme: true, line: true);
			fade.FadeIn("Spoofed BuildGUID: " + (string)Registry.GetValue(keyName2, "BuildGUID", "default"), Theme: true, line: true);
			Console.WriteLine("\n █\u2003█▄░█\u2003█▀▀\u2003█▀█\n█\u2003█░▀█\u2003█▀░\u2003█▄█\n");
			fade.FadeIn("Spoof Sucessfully!", Theme: true, line: true);
			fade.FadeIn("use New Rockstar ACC", Theme: false, line: true);
			fade.FadeIn("use New Discord ACC", Theme: false, line: true);
			fade.FadeIn("Use New Steam ACC", Theme: false, line: true);
			fade.FadeIn("Use VPN", Theme: false, line: true);
			Console.ReadKey();
		}

		public static string GenID(int length)
		{
			Random random = new Random();
			string element = "123457869";
			return new string((from s in Enumerable.Repeat(element, length)
							   select s[random.Next(s.Length)]).ToArray());
		}

		public void SpoofGlobal()
		{
			StartPoint:
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("                                ┌────────────────────────────────────────────────────┐\n" +

				"                                │                                                    │\n" +
				"                                │                                                    │\n" +
				"                                │          [1]: Kill Discord, Steam and FiveM        │\n" +
				"                                │                                                    │\n" +
				"                                │          [2]: Spoofing PC Hardware                 │\n" +
				"                                │                                                    │\n" +
				"                                │          [3]: Compress PC Drive                    │\n");

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                                │                                                    │\n" +
				"                                │          [4]: Conform GPU System Drivers           │\n" +
				"                                │                                                    │\n" +
				"                                │          [5]: Spoof Hard Disk                      │\n" +
				"                                │                                                    │\n" +
				"                                │          [6]: Spoof Account                        │\n" +
				"                                │                                                    │\n" +
				"                                │                                                    │\n" +
				"                                │                                                    │\n" +
				"                                └────────────────────────────────────────────────────┘");


			Console.WriteLine("\n\n\n\n");
			fade.FadeIn("Choice: ",true,false);
			String Chooice = Console.ReadLine();
            switch (Chooice)
            {
				case "1":
					Console.Clear();
					fade.FadeIn("Killing Discord,Steam,FiveM", true, false);
					KillDiscord();
					goto StartPoint;
					break;

				case "2":
					Console.Clear();
					fade.FadeIn("Spoofing PC Hardware...", true, false);
					Thread.Sleep(7000);
					goto StartPoint;
					break;
				case "3":
					Console.Clear();
					fade.FadeIn("Compress PC Drive...", true, false);
					Thread.Sleep(7000);
					goto StartPoint;
					break;
				case "4":
					Console.Clear();
					fade.FadeIn("Conform GPU System Drivers...", true, false);
					Thread.Sleep(7000);
					goto StartPoint;
					break;
				case "5":
					Console.Clear();
					fade.FadeIn("Spoof Hard Disk...", true, false);
					Thread.Sleep(7000);
					goto StartPoint;
					break;
				case "6":
					
					Console.Clear();
					GetMethods();
					
					break;
				
			}
			Thread.Sleep(1500);
			initSpoof();
		}
		public void KillDiscord()
        {
			

			string[] array = new string[3]
			{
			"discord", "FiveM", "steam"
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
						
					}
				}
			}
		}
		public void GetMethods()
        {
			
			fade.FadeIn("Spoofing Account..", true, true);
			fade.FadeIn("Press enter for Every Step!", true, true);
			fade.FadeIn("1. Revo uninstaller GT 5 & FiveM!", true, true);
			Console.ReadKey();
			fade.FadeIn("2. Buy New Gta 5 downloadable Account (dont login yet)", true, true);
			Console.ReadKey();
			fade.FadeIn("3. (Oly for Token ban) Change IP and MAC addresse", true, true);
			Console.ReadKey();
			fade.FadeIn("4. Login on a unbanned pc with the new Account (Shadow Pc or Pc from a Friend)", true, true);
			Console.ReadKey();
			fade.FadeIn("5. Join a Server and Play 2-4 hours", true, true);
			Console.ReadKey();
			fade.FadeIn("6. (on your Pc) Login in his steam & your new GTA 5 Account and join a server", true, true);
			Console.ReadKey();
			fade.FadeIn("7. Login now in your Main Steam and you are Fully unbanned", true, true);
			Console.ReadKey();
			fade.FadeIn("Have Fun!", true, true);
			Thread.Sleep(2000);
			Environment.Exit(0);	
		}
	}
	public class Fade
	{
		public void FadeIn(string Text, bool Theme, bool line)
		{
			bool flag = false;
			if (Theme)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write("[");
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("+");
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write("]  ");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write("[");
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("-");
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write("]  ");
			}
			for (int i = 0; i < Text.Length; i++)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Thread.Sleep(35);
				Console.Write(Text[i]);
			}
			if (line)
			{
				Console.WriteLine();
			}
		}

		public void FadeLogo(int delay)
		{
			
		}
	}
}
