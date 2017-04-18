using Evol.Domain.Modules;
using Evol.TMovie.Data;
using Evol.TMovie.Domain;
using Evol.TMovie.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Evol.TMovie.DataTests
{
    [DependOn(typeof(TMovieDataModule), typeof(TMovieDomainModule))]
    public class TMovieDataTestModule : AppModule
    {
        public override void Initailize()
        {
            DtoObjectMapInitiator.Create(this.GetType().GetTypeInfo().Assembly);
            InitDependModule<TMovieDataTestModule>();
            base.Initailize();
            DtoObjectMapInitiator.Initialize();
        }
    }
}
