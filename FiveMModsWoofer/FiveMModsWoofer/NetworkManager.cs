using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace FiveMModsWoofer
{
	public class NetworkManager
	{
		public enum Options
		{
			Register = 1,
			Login,
			License
		}

		public class LoginSystemV1
		{
			public enum Options
			{
				Register = 1,
				Login,
				License
			}

			public TcpClient tcpClient = new TcpClient();

			public StreamReader reader;

			public StreamWriter writer;

			public string UserPasswort { get; set; }

			public string UserName { get; set; }

			public string License { get; set; }

			public string HWID { get; set; }

			public LoginSystemV1(string serverip)
			{
				tcpClient.Connect(serverip, 6005);
				reader = new StreamReader(tcpClient.GetStream());
				writer = new StreamWriter(tcpClient.GetStream());
			}

			public bool Register(string Name, string Passwort, string Currenthwid, string license)
			{
				UserName = Name;
				UserPasswort = Passwort;
				HWID = Currenthwid;
				sendPacket(Options.Register.ToString() + " " + UserName + " " + UserPasswort + " " + HWID + " " + license);
				return true;
			}

			public bool Login(string Name, string Passwort, string Currenthwid)
			{
				UserName = Name;
				UserPasswort = Passwort;
				HWID = Currenthwid;
				sendPacket(Options.Login.ToString() + " " + UserName + " " + UserPasswort + " " + HWID);
				string text = readPacket();
				if (text == "False")
				{
					return false;
				}
				if (text == "True")
				{
					return true;
				}
				return false;
			}

			public bool Checklicense(Enum OPLicense, string license)
			{
				sendPacket(Options.License.ToString() + " " + license);
				string text = readPacket();
				if (text == "False")
				{
					return false;
				}
				return true;
			}

			public string readPacket()
			{
				return reader.ReadLine();
			}

			public void sendPacket(string packet)
			{
				writer.WriteLine(packet);
				writer.Flush();
			}
		}
	}
}
