using Evol.Domain.Modules;
using Evol.TMovie.Data;
using Evol.TMovie.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Tests
{
    [DependOn(typeof(TMovieDataModule), typeof(TMovieDomainModule))]
    public class TMovieDataTestModule : AppModule
    {
        public override void Initailize()
        {
            (new ObjectToObjectMapInitiator()).Init(this.GetType().GetTypeInfo().Assembly);
            InitDependModule<TMovieDataTestModule>();
            base.Initailize();
        }
    }
}
