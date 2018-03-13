using Evol.Domain.Dto;
using Evol.Domain.Messaging;
using Sample.Domain.Commands;
using Sample.Domain.Models.AggregateRoots;
using Sample.Domain.Models.Entities;
using Sample.Domain.QueryEntries;
using Sample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.CommandHandlers
{
    public class PostCommandHandler :
        ICommandHandler<PostCreateCommand>,
        ICommandHandler<PostDeleteCommand>,
        ICommandHandler<CommentCreateCommand>,
        ICommandHandler<CommentDeleteCommand>
    {
        private IPostRepository postRepository;

        private ICommentRepository commentRepository;

        public PostCommandHandler(IPostRepository postRepos, ICommentRepository commentRepos)
        {
            postRepository = postRepos;
            commentRepository = commentRepos;
        }

        public async Task ExecuteAsync(PostCreateCommand command)
        {
            var post = command.Input.Map<Post>();
            post.Id = Guid.NewGuid();
            post.CreateTime = DateTime.Now;
            await postRepository.InsertAsync(post);
        }

        public async Task ExecuteAsync(PostDeleteCommand command)
        {
            await postRepository.DeleteAsync(command.Input.Id);
        }

        public async Task ExecuteAsync(CommentCreateCommand command)
        {
            var item = command.Input.Map<Comment>();
            item.Id = Guid.NewGuid();
            item.CreateTime = DateTime.Now;
            await commentRepository.InsertAsync(item);
        }

        public async Task ExecuteAsync(CommentDeleteCommand command)
        {
            await commentRepository.DeleteAsync(command.Input.Id);
        }
    }
}
