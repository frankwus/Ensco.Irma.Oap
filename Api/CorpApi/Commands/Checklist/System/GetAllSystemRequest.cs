﻿using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.System
{
    public class GetAllSystemRequest : IRequest<IEnumerable<OapSystem>>
    { 
        public GetAllSystemRequest()
        {
           
        }         
    }
}