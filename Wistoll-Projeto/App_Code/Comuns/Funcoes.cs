using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Funcoes
/// </summary>
/// 
namespace Wistoll.Funcoes
{
    public class Funcoes
    {
        /// <summary>
        /// Cripitografa um texto qualquer, utilizando um HASH escolhido
        /// </summary>
        /// <param name="texto">Palavra a ser criptografada</param>
        /// <param name="nomeHash">Parametro para criar a criptografia. Sendo: SHA1, SHA-256, SHA-384, SHA-512 ou MD5 (Inserindo somente estas opções)</param>
        /// <returns>Retorna o texto criptografado</returns>
        public static string HashTexto(string texto)
        {
            HashAlgorithm hash = HashAlgorithm.Create("SHA-512");

            if (hash == null)
            {
                throw new ArgumentException("Nome de Hash inválido");
            }

            byte[] hashByte = hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

            return Convert.ToBase64String(hashByte);
        }

        /// <summary>
        /// Pegar um valor textual e converte-lô para Base64
        /// </summary>
        /// <param name="texto">Texto "limpo"</param>
        /// <returns>Retorna o texto convertido para a base 64</returns>
        public static string Base64Codifica(string texto)
        {
            byte[] stringBase = new byte[texto.Length];
            stringBase = Encoding.UTF8.GetBytes(texto);

            string textoCodificado = Convert.ToBase64String(stringBase);

            return textoCodificado;
        }

        public static string Base64Decodifica(string textoBase)
        {
            var encode = new UTF8Encoding();
            var utfDecode = encode.GetDecoder();

            byte[] stringValor = Convert.FromBase64String(textoBase);

            int contador = utfDecode.GetCharCount(stringValor, 0, stringValor.Length);
            char[] decodeChar = new char[contador];

            utfDecode.GetChars(stringValor, 0, stringValor.Length, decodeChar, 0);

            string resultado = new String(decodeChar);
            return resultado;
        }

        //chave simetria (cripto)
        //hash 
        //memoria->buffer->stram->io
        //cache->dispose->alocação
        //using
        //aes
        //Rinjdael

        public static string AESCodifica(string textoLimpo)
        {
            //Frase de segurança... Mais embaralhada melhor
            //Poréns: Mais embaralhado, mais processo em memória
            string fraseSeguranca = "uPK4h8tiSrx6g/Wg206IUuGySGTpOZ8W2sHc1fG1nF7b0fh017NlYYAPjHQgM66BUJy4Yq0YyC1gkBRn5N7e5w==";
            byte[] vetorTextoLimpo = Encoding.Unicode.GetBytes(textoLimpo);

            //using AES - classe de auxilio (algoritmo simetrico)
            using (Aes encryptor = Aes.Create())
            {
                //utilização rfc passando bloco de memoria(16bits, 32bits, 64bits...)
                //passagem da frase alocando e com isso persistindo para uso de codificação de charac by charac
                Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes
                (
                    fraseSeguranca,
                    //utilizando o rfc passando os blocos de memoria (16 e 32 bits)
                    new byte[] { 0x49, 0x79, 0x61, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }
                );
                encryptor.Key = rdb.GetBytes(32);
                encryptor.IV = rdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    //criar partição de criptografia. Cada charac é convertido e alocado. Passo todo o valor codificado
                    //para o pedação de memoria (salt) persistindo o valor
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        //escreve o texto final codificado, passando o inicio e fim do valor (vetorTextoLimpo)
                        cs.Write(vetorTextoLimpo, 0, vetorTextoLimpo.Length);
                        //dispose(limpar e fechar) na galera...
                        //no memoryStram utiliza-se o close
                        cs.Close();
                    }
                    //processo semelhante a base64... "Traduzir o texto"
                    //byte para "textual"
                    //vou usar a mesma variavel de entrada para a saida...
                    //preguiça de criar outra e não tem porque tambem!
                    textoLimpo = Convert.ToBase64String(ms.ToArray());
                }
            }
            return textoLimpo;
        }

        public static string AESDecodifica(string textoSujo)
        {
            try
            {
                string fraseSeguranca = "uPK4h8tiSrx6g/Wg206IUuGySGTpOZ8W2sHc1fG1nF7b0fh017NlYYAPjHQgM66BUJy4Yq0YyC1gkBRn5N7e5w==";
                byte[] vetorTextoSujo = Convert.FromBase64String(textoSujo);
                using (Aes decryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes
                    (
                        fraseSeguranca,
                        new byte[] { 0x49, 0x79, 0x61, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }
                    );
                    decryptor.Key = rdb.GetBytes(32);
                    decryptor.IV = rdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(vetorTextoSujo, 0, vetorTextoSujo.Length);
                            cs.Close();
                        }
                        textoSujo = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                return "Erro ao decodificar";
            }
            return textoSujo;
        }
    }
}