using System;
using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleMapper
    {
        public ArticleDto Map(Article article)
        {
            //TODO
            return new ArticleDto();
        }

        public Article Map(ArticleDto articleDto)
        {
            // Nicht Teil dieser Challenge.
            return new Article();
        }
    }
}
