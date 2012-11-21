using System;
using System.Collections;
using System.Xml;

namespace REACH.Common.Base
{
	/* Parse the configuration file */
	public class Configuration
	{
		private const string DEFAULT_IP = "127.0.0.1";
		private const int DEFAULT_PORT = 4296;

		private const string CONFIG_FILE_NAME = "config.xml";

		public static Hashtable GetSettings()
		{
			Hashtable hash = new Hashtable();

			hash.Add("ip", DEFAULT_IP);
			hash.Add("port", DEFAULT_PORT);

			try
			{
				XmlTextReader xml = new XmlTextReader(CONFIG_FILE_NAME);
				while (xml.Read())
				{
					switch (xml.NodeType)
					{
						case XmlNodeType.Element:
							if (xml.Name.ToUpper() == "IP")
								if (xml.Read() && xml.NodeType == XmlNodeType.Text)
									hash["ip"] = xml.Value;
							if (xml.Name.ToUpper() == "PORT")
								if (xml.Read() && xml.NodeType == XmlNodeType.Text)
									hash["port"] = xml.Value;
							break;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception in Service: " + ex.Message);
				Console.WriteLine("Process started with default values.");
			}

			return hash;
		}
	}
}
