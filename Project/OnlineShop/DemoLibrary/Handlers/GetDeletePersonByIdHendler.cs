using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DemoLibrary.DataAccess;

namespace DemoLibrary.Handlers
{
    internal class GetDeletePersonByIdHendler: IRequestHandler<GetDeletePersonByIdQuery, PersonModel>
    {
        private readonly IDataAccess data;
        public GetDeletePersonByIdHendler(IDataAccess data)
        {
            this.data = data;
        }
        public async Task<PersonModel> Handle(GetDeletePersonByIdQuery request, CancellationToken cancellationToken)
        {
            return data.DeletePerson(request.Id);

        }         
    }
}
