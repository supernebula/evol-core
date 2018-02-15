using Evol.Domain.Messaging;
using Sample.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.CommandHandlers
{
    class PostCommandHandler :
        ICommandHandler<PostCreateCommand>,
        ICommandHandler<PostDeleteCommand>,
        ICommandHandler<CommentCreateCommand>,
        ICommandHandler<CommentDeleteCommand>
    {
        public Task ExecuteAsync(PostCreateCommand command)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync(PostDeleteCommand command)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync(CommentCreateCommand command)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync(CommentDeleteCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
