using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Common
{
    public abstract class HandlersBase
    {
        protected readonly IDataBaseContext _dbContext;
        protected readonly IMapper _mapper;
        protected HandlersBase(IDataBaseContext dbContext, IMapper mapper) =>
              (_dbContext, _mapper) = (dbContext, mapper);

        protected List<Category> SubcategoriesFind(IDataBaseContext dataBase, long parenrId, List<Category> listCategories)
        {

            var list = dataBase.CategoryConnection
                .Include(x => x.Child.Product)
                .Where(x => x.ParentId == parenrId).ToList();
            foreach (var item in list)
            {
                if (item == null)
                {

                    return listCategories;
                }
                listCategories.Add(item.Child);
                SubcategoriesFind(dataBase, item.Child.Id, listCategories);

            }

            return listCategories;
        }
    }
}
