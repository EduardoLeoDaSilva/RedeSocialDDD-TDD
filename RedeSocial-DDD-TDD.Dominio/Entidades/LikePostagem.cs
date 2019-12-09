namespace RedeSocial_DDD_TDD.Dominio.Entidades
{
    public class LikePostagem
    {
        public int LikeId { get; set; }
        public int PostagemId { get; set; }
        public Like Like { get; set; }
        public Postagem Postagem { get; set; }

        private LikePostagem()
        {
                
        }
        public LikePostagem(int likeId, int postagemId, Like like, Postagem postagem)
        {
            LikeId = likeId;
            PostagemId = postagemId;
            Like = like;
            Postagem = postagem;
        }
    }
}