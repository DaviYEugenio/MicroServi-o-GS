using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Base
{
    public class RepositoryBase : IRepositoryBase
    {
        private Dictionary<string, string> _databases;
        private string _connectionString;
        private string _inviteHashSalt;

        public Dictionary<string, string> Databases
        {
            get { return this._databases; }
        }

        public string ConnectionString
        {
            get { return this._connectionString; }
        }

        public string InviteHashSalt
        {
            get { return this._inviteHashSalt; }
        }

        public RepositoryBase(dynamic databases, string connectionString, string inviteHashSalt)
        {
            this._databases = databases;
            this._connectionString = connectionString;
            this._inviteHashSalt = inviteHashSalt;
        }
    }
}