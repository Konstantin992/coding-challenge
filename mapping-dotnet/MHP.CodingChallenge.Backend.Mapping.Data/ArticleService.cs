using System;
using System.Collections.Generic;
using System.Linq;
using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleService
    {
        private ArticleRepository _articleRepository;
        private ArticleMapper _articleMapper;

        public ArticleService(ArticleRepository articleRepository, ArticleMapper articleMapper)
        {
            _articleRepository = articleRepository;
            _articleMapper = articleMapper;
        }

        public List<ArticleDto> GetAll()
        {
            List<Article> articles = _articleRepository.GetAll();
            var dtos = articles.Select(article => _articleMapper.Map(article))
                               .Select(articles => 
                               {
                                    articles.Blocks = articles.Blocks.OrderBy(b => b.SortIndex).ToList();
                                    return articles;
                               }).ToList();
            return dtos;
        }

        public object GetById(long id)
        {
            Article article = _articleRepository.FindById(id);
            var dto = _articleMapper.Map(article);
            return dto;
        }

        public object Create(ArticleDto articleDto)
        {
            Article create = _articleMapper.Map(articleDto);
            _articleRepository.Create(create);
            return _articleMapper.Map(create);
        }
    }
}
