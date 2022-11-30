﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Services
{
    public class WalletService
    {
        private void GenerateHash(out byte[] AddressHash, out byte[] AddressKey)
        {
            var address = GenerateAddress();
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                AddressKey = hash.Key;
                AddressHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(address));
            }
        }

        private bool VerifyAddress(string Address, byte[] AddressHash, byte[] AddressKey)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512(AddressKey))
            {
                var computedHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Address));
                return computedHash.SequenceEqual(AddressHash);
            }
        }
        private string GenerateAddress()
        {
            var address = "0x";
            var str = "ZQAx0sewCq2SWFu7yhn1jEbgTokMI3KLOPml4DiGRptrB5H8YNJUfv6cXVd9az";
            var rnd = new Random();
            for (int i = 0; i < 23; i++)
            {
                address += str[rnd.Next(0, 61)];
            }
            return address;
        }
    }
}
