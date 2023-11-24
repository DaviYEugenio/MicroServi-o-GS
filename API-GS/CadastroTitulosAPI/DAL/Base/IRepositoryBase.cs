using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Base
{
    public interface IRepositoryBase
    {
        Dictionary<string, string> Databases { get; }
        string ConnectionString { get; }
        string InviteHashSalt { get; }
    }
}
