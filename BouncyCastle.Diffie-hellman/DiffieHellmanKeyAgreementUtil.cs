using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace BouncyCastle.Diffie_hellman
{
    public static class DiffieHellmanKeyAgreementUtil
    {
        /// <summary>
        /// Calculate Secret key agreement between two parties, example: https://8gwifi.org/ecfunctions.jsp
        /// </summary>
        /// <param name="privateKey">EC-Private Key Alice</param>
        /// <param name="publicKey">Public key pair</param>
        /// <returns>Agreed secret key</returns>
        public static string GetPairKey(string privateKey, string publicKey)
        {
            var privKey = ReadRemPrivate(privateKey);
            var pubKey = ReadRemPublic(publicKey);
            var agreement = AgreementUtilities.GetBasicAgreement("ECDH");
            agreement.Init(privKey);
            var secret = agreement.CalculateAgreement(pubKey);
            return Convert.ToBase64String(secret.ToByteArrayUnsigned());
        }
        static ECPrivateKeyParameters ReadRemPrivate(string pemContent)
        {
            var pr = new PemReader(new StringReader(pemContent));
            var keyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
            var privateKeyParams = (ECPrivateKeyParameters)keyPair.Private;
            return privateKeyParams;
        }
        static ECPublicKeyParameters ReadRemPublic(string pemContent)
        {
            var pemReader = new PemReader(new StringReader(pemContent));
            var keyPair = (AsymmetricKeyParameter)pemReader.ReadObject();
            var publicKeyParams = (ECPublicKeyParameters)keyPair;
            return publicKeyParams;
        }
    }
}
