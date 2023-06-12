using System.Security.Cryptography;
using System.Text;

namespace RSA_NET_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 生成RSA密钥对
                GenerateKeys(out string publicKey, out string privateKey);
                // 获取公钥和私钥
                //string publicKey = rsa.ToXmlString(false);
                //string privateKey = rsa.ToXmlString(true);

                Console.WriteLine("=== RSA密钥对 ===");
                Console.WriteLine("公钥:");
                Console.WriteLine(publicKey);
                Console.WriteLine("私钥:");
                Console.WriteLine(privateKey);
                Console.WriteLine("=================");

                Console.WriteLine("\n请输入要加密的文本:");
                string plainText = Console.ReadLine();

                // 使用公钥加密文本
                string encryptedText = Encrypt(plainText, publicKey);
                Console.WriteLine("加密后的文本: " + encryptedText);

                // 使用私钥解密文本
                string decryptedText = Decrypt(encryptedText, privateKey);
                Console.WriteLine("解密后的文本: " + decryptedText);

                Console.WriteLine("\n请输入要签名的文本:");
                string textToSign = Console.ReadLine();

                // 使用私钥对文本进行签名
                string signature = Sign(textToSign, privateKey);
                Console.WriteLine("签名结果: " + signature);

                // 使用公钥验证签名
                bool isSignatureValid = Verify(textToSign, signature, publicKey);
                Console.WriteLine("签名验证结果: " + isSignatureValid);

            }
            catch (Exception e)
            {
                Console.WriteLine("发生错误: " + e.Message);
            }
        }

        // 生成RSA密钥对
        public static void GenerateKeys(out string publicKey, out string privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                publicKey = rsa.ToXmlString(false);
                privateKey = rsa.ToXmlString(true);
            }
        }

        // 使用公钥加密文本
        public static string Encrypt(string plainText, string publicKey)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                byte[] encryptedBytes = rsa.Encrypt(plainBytes, false);
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        // 使用私钥解密文本
        public static string Decrypt(string encryptedText, string privateKey)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, false);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        // 使用私钥对文本进行签名
        public static string Sign(string plainText, string privateKey)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                byte[] signatureBytes = rsa.SignData(plainBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                return Convert.ToBase64String(signatureBytes);
            }
        }

        // 使用公钥验证签名
        public static bool Verify(string plainText, string signature, string publicKey)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] signatureBytes = Convert.FromBase64String(signature);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                bool isSignatureValid = rsa.VerifyData(plainBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                return isSignatureValid;
            }
        }
    }
}