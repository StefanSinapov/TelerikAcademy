using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
	public interface IEncryptable
	{
		bool IsEncrypted { get; }
		void Encrypt();
		void Decrypt();
	}
}
