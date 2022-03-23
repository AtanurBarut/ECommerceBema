using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hash.Sha256
{
    public interface IHashService
    {
        string CreateHash(string plainText);
        bool CompareHash(string hashedText, string plainText);
    }
}
