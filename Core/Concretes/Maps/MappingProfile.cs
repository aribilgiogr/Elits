using AutoMapper;
using Core.Concretes.DTOs.Comment;
using Core.Concretes.DTOs.Follower;
using Core.Concretes.DTOs.Post;
using Core.Concretes.DTOs.PostLike;
using Core.Concretes.Entities;

namespace Core.Concretes.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Post
            // ReverseMap: Post -> PostDto ve PostDto -> Post haritalamasını yapar.
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<CreatePostDto, Post>();
            CreateMap<UpdatePostDto, Post>();
            #endregion

            #region Comment
            CreateMap<Comment, CommentDto>();
            CreateMap<CreateCommentDto, Comment>();
            CreateMap<UpdateCommentDto, Comment>();
            #endregion

            #region PostLike
            CreateMap<PostLike, PostLikeDto>();
            CreateMap<CreatePostLikeDto, PostLike>();
            #endregion

            #region Follower
            CreateMap<Follower, FollowerDto>();
            CreateMap<CreateFollowerDto, Follower>();
            #endregion
        }
    }
}
