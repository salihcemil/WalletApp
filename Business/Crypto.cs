using Babel.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Business.Models;

namespace Business
{
    public static class Crypto
    {
        public static string GetHash(string ObjectString)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(ObjectString));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public static string getSignature(string textToSign, string publicKey, string privateKey)
        {
            ECDsaSignature signer;
            signer = ECDsaSignature.FromKeys(publicKey, privateKey);
            byte[] byteStr = Encoding.Default.GetBytes(textToSign);
            byte[] byteSignature = signer.SignData(byteStr);

            return Encoding.Default.GetString(byteSignature);
        }

        public static bool CheckSignature(Input inp)
        {
            List<string> stringList = inp.ScriptSign.Split(' ').ToList();
            string signature = stringList[0];
            string receiverPublicKey = stringList[1];
            string stringToVerify = inp.PrevTransactionHash + " " + inp.OutputIndex.ToString();

            ECDsaSignature verifier = ECDsaSignature.FromKeys(receiverPublicKey);
            return verifier.VerifyData(Encoding.Default.GetBytes(stringToVerify), Encoding.Default.GetBytes(signature));
        }
    }
}
