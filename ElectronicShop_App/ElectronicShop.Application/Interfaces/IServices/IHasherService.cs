using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicShop.Application.Interfaces.IServices
{
    public interface IHasherService
    {
        string ComputeSha256Hash(string data);

        string Convert256BytesToString(byte[] bytes);
    }
}
