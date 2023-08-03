using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Decopack.Servicios
{

    public class Seguridad
    {

        static string key = "Decopack";
        public static string GenerarSHA(string sCadena)
        {
            System.Text.UnicodeEncoding ueCodigo = new System.Text.UnicodeEncoding();

            byte[] ByteSourceText = ueCodigo.GetBytes(sCadena);

            SHA1CryptoServiceProvider SHA = new SHA1CryptoServiceProvider();

            byte[] ByteHash = SHA.ComputeHash(ueCodigo.GetBytes(sCadena));

            return Convert.ToBase64String(ByteHash);
        }

        public static string EncriptarMD5(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
            0, ArrayResultado.Length);
        }

        public static string DesencriptarMD5(string textoEncriptado)
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =
            Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        //public static string Encripta(string Pass, string user)
        //{
        //    string Clave;
        //    int i;
        //    string Pass2;
        //    string CAR;
        //    string Codigo;
        //    Clave = user;
        //    Pass2 = "";
        //    for (i = 1; i <= Pass.Length; i++)
        //    {
        //        CAR = Pass.Substring( i, 1);
        //        Codigo = Strings.Mid(Clave, ((i - 1) % Strings.Len(Clave)) + 1, 1);
        //        Pass2 = Pass2 + Strings.Right("0" + Conversion.Hex(Strings.Asc(Codigo) ^ Strings.Asc(CAR)), 2);
        //    }

        //    return Pass2;
        //}

        //public static string DesEncripta(string Pass, string user)
        //{
        //    string Clave;
        //    int i;
        //    string Pass2;
        //    string CAR;
        //    string Codigo;
        //    int j;

        //    Clave = user;
        //    Pass2 = "";
        //    j = 1;
        //    for (i = 1; i <= Pass.Length; i += 2)
        //    {
        //        CAR = Pass.Substring( i, 2);
        //        Codigo = Substring(Clave, ((j - 1) % Clave.Length) + 1, 1);
        //        Pass2 = Pass2 + Strings.Chr(Strings.Asc(Codigo) ^ Conversion.Val("&h" + CAR));
        //        j = j + 1;
        //    }
        //    return Pass2;
        //}
    }

}
