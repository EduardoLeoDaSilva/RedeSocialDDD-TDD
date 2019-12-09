namespace RedeSocial_DDD_TDD.DTOs
{
    public class PerfilDTO : BaseDTO
    {
        public UsuarioDTO Usuario { get; set; }
        public string Interesse { get; set; }
    }
}