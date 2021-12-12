using AutoMapper;
using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DB.Blocks;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO.Blocks;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleMapper
    {
        public ArticleDto Map(Article article)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDto>();
                cfg.CreateMap<Image, ImageDto>();
                cfg.CreateMap<ArticleBlock, ArticleBlockDto>()
                    .Include<GalleryBlock, GalleryBlockDto>()
                    .Include<ImageBlock, ImageBlockDto>()
                    .Include<TextBlock, TextBlockDto>()
                    .Include<VideoBlock, VideoBlockDto>();
                cfg.CreateMap<GalleryBlock, GalleryBlockDto>();

                cfg.CreateMap<ImageBlock, ImageBlockDto>();

                cfg.CreateMap<TextBlock, TextBlockDto>();
                cfg.CreateMap<VideoBlock, VideoBlockDto>();
            });

            configuration.AssertConfigurationIsValid();
            var mapper = configuration.CreateMapper();

            return mapper.Map<ArticleDto>(article);
        }

        public Article Map(ArticleDto articleDto)
        {
            // Nicht Teil dieser Challenge.
            return new Article();
        }
    }
}
