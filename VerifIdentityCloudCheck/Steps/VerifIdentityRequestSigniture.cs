using DecisionsFramework.Design.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The simplest types of steps are method based sync steps.  Simply write whatever
/// .NET code you want and use an attribute on the CLASS or on the METHOD itself to 
/// register that code with the workflow engine as a flow step.
/// </summary>
namespace VerifIdentityCloudCheck.Steps
{
	[AutoRegisterMethodsOnClass(true, "Integration/VerifIdentity")]
	public class VerifIdentityRequestSigniture
	{
        public string RequestSigniture (string key,	string secret, string nonce, string timestamp, string data, string path)
			{
			
			// Set up some dummy parameters. Use a SortedDictionary to sort alphabetically.
			var parameterMap = new SortedDictionary<string, string>();
			parameterMap["key"] = key;
			parameterMap["nonce"] = nonce;
			parameterMap["timestamp"] = timestamp;
			parameterMap["data"] = data;
			// Build the signature string from the parameters.
			var signatureString = new System.Text.StringBuilder();
			signatureString.Append(path);
			foreach (KeyValuePair<string, string> param in parameterMap)
			{
				signatureString.Append(param.Key);
				signatureString.Append("=");
				signatureString.Append(param.Value);
				signatureString.Append(";");
			}
			// Create the HMAC SHA-256 Hash from the signature string.
			var encoding = new System.Text.UTF8Encoding();
			byte[] keyByte = encoding.GetBytes(secret);
			byte[] messageBytes = encoding.GetBytes(signatureString.ToString());
			using (var hmacsha256 = new HMACSHA256(keyByte))
			{
				byte[] hashedMessage = hmacsha256.ComputeHash(messageBytes);
				string signatureHex = "";
				for (int i = 0; i < hashedMessage.Length; i++)
				{
					signatureHex += hashedMessage[i].ToString("X2"); // hex format
				}
				// Outputs: 53ccc8563d21393bbac5a5a693e0ba7cc408f83dfb04008122510eee9e80aa86
				// Console.WriteLine("Signature: " +signatureHex.ToLower());
				return signatureHex.ToLower();
			};
        }

    }
}
