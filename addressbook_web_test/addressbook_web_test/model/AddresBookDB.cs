﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAddressbookTests
{
    public class AddresBookDB : LinqToDB.Data.DataConnection
    {
        public AddresBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<DataContact> Contacts { get { return GetTable<DataContact>(); } }

        public ITable<GroupWithContact> GCR { get { return GetTable<GroupWithContact>(); } }

    }
}
