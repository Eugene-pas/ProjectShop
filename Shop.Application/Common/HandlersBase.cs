using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
                .Include(x => x.Category.Product)
                .Where(x => x.ParentId == parenrId).ToList();
            foreach (var item in list)
            {
                if (item == null)
                {

                    return listCategories;
                }
                listCategories.Add(item.Category);
                SubcategoriesFind(dataBase, item.Category.Id, listCategories);

            }

            return listCategories;
        }
    }
}
