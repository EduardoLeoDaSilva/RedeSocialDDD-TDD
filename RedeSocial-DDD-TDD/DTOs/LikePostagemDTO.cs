namespace RedeSocial_DDD_TDD.DTOs
{
    public class LikePostagemDTO : BaseDTO
    {
        public int LikeId { get; set; }
        public int PostagemId { get; set; }
        public LikeDTO Like { get; set; }
        public PostagemDTO Postagem { get; set; }

        public LikePostagemDTO()
        {
                
        }

        public LikePostagemDTO(int likeId, int postagemId, LikeDTO like, PostagemDTO postagem)
        {
            LikeId = likeId;
            PostagemId = postagemId;
            Like = like;
            Postagem = postagem;
        }
    }
}