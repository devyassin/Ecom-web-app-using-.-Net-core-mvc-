using DAL.Entity;
using DAL.Repo;
using Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryService
    {
        public List<ListCategoryMV> GetListCategory()
        {
            
            var categorieRepos = new CategoryRepos();


            List<ListCategoryMV> listCategoryMVs = new List<ListCategoryMV>();

            foreach (var item in categorieRepos.GetAll())
            {
                ListCategoryMV CategoryMV = new ListCategoryMV();
                CategoryMV.Id = item.Id;
                CategoryMV.Name = item.Name;
                CategoryMV.DisplayOrder= item.DisplayOrder;

                listCategoryMVs.Add(CategoryMV);
            }
            return listCategoryMVs;
        }

        public void AjouterCategory(CreateCategoryMV model) {
            var categorieRepos = new CategoryRepos();
            Category category = new Category();
            category.Id = model.Id;
            category.Name = model.Name;
            category.DisplayOrder= model.DisplayOrder;

            categorieRepos.Create(category);

        }

        public UpdateCategoryMV TrouverCategory(int id)
        {
            CategoryRepos categoryRepos=new CategoryRepos();
            UpdateCategoryMV categoryMV = new UpdateCategoryMV();
            Category category = categoryRepos.Find(id);
            categoryMV.Id = category.Id;
            categoryMV.Name = category.Name;
            categoryMV.DisplayOrder = category.DisplayOrder;
            return categoryMV;

        }

        public void ModifierCategory(UpdateCategoryMV model )
        {
            CategoryRepos categoryRepos = new CategoryRepos();
            Category category = new Category();
            category.Id= model.Id;
            category.Name = model.Name;
            category.DisplayOrder= model.DisplayOrder;
            categoryRepos.Update(category);

        }

        public void SupprimerCategorie(UpdateCategoryMV model)
        {
            CategoryRepos categoryRepos = new CategoryRepos();
            Category category = new Category();
            category.Id=model.Id;
            category.Name=model.Name;
            category.DisplayOrder= model.DisplayOrder;
            categoryRepos.Delete(category);

        }

    }
}
