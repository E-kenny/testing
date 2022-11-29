﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Models.Entities
{
    public enum Type
    {
        Debit, Credit
    }

    public class Transaction
    {
        public string Id { get; set; }
        public Type Type { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public Wallet Wallet { get; set; }
    }
}
