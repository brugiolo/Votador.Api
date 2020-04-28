using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Votador.Business.Validations;

namespace Votador.Business.Models
{
    public partial class Usuario : Entidade
    {
        [NotMapped]
        public static string SecretGuid = "e91ef2c0-b9a7-4da1-be65-37762c3d9f8a";

        [NotMapped]
        public string Token { get; internal set; }

        public Usuario()
        {
            Votos = new HashSet<Voto>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }

        public override bool IsValid()
        {
            var usuarioValidacao = new UsuarioValidacao();
            ValidationResult = usuarioValidacao.Validate(this);

            return ValidationResult.IsValid;
        }

        public static string GerarSenhaGashMD5(string senha)
        {
            var md5Hash = MD5.Create(HashAlgorithmName.MD5.Name);
            var computedHash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < computedHash.Length; i++)
            {
                stringBuilder.Append(computedHash[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public static bool CompararHashMD5(string senha, string senhaSalva)
        {
            var computedHash = GerarSenhaGashMD5(senha);
            var comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(computedHash, senhaSalva) == 0;
        }
    }
}
