using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Dto
{
    /// <summary>
    ///  object-object mapper. 
    ///  The best place to put the configuration code is in application startup, 
    ///  such as the Global.asax file for ASP.NET applications.
    /// </summary>
    /// <typeparam name="TFrom"></typeparam>
    public interface ICanMapFrom<TFrom>
    {
    }
}
